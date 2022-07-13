using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Contracts;
using System.Net;
using System.Net.Sockets;

namespace BuisnessLogic
{
    public class UserLog : IUserLog
    {
        private string UserIp { get; set; }
        private DateTime SearchTime { get; set; }

        private string Input { get; set; }

        private string Anagram { get; set; }
        public UserLog()
        {

        }

        public void AddUserLogToDB(string input, string anagram)
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                var user = new UserLog();

                user.UserIp = GetIP();
                user.SearchTime = DateTime.Now;
                user.Input = input;
                user.Anagram = anagram;

                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserLog (UserIP, SearchTime, SearchWord, Anagram) VALUES (@userIP, @searchTime, @searchWord, @anagram)", connection);
                cmd.Parameters.AddWithValue("@userIP", user.UserIp);
                cmd.Parameters.AddWithValue("@searchTime", user.SearchTime);
                cmd.Parameters.AddWithValue("@searchWord", user.Input);
                cmd.Parameters.AddWithValue("@anagram", user.Anagram);

                cmd.ExecuteNonQuery();

                connection.Close(); //Do I really need to close it?
            }
        }


        private string GetIP()
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ip)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress.ToString();
                }
            }
            return "No IP Address Found";
        }

    }
}
