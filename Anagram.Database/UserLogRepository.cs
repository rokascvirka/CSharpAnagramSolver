using Contracts;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic;

namespace Anagram.Database
{
    public class UserLogRepository
    {
        private const string ConnectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

        public void AddUserLogToDB(string input, string anagram, string IP)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                var user = new UserLogModel();

                user.UserIP = IP;
                user.SearchTime = DateTime.Now.ToString();
                user.SearchWord = input;
                user.Anagram = anagram;

                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserLog (UserIP, SearchTime, SearchWord, Anagram) VALUES (@userIP, @searchTime, @searchWord, @anagram)", connection);
                cmd.Parameters.AddWithValue("@userIP", user.UserIP);
                cmd.Parameters.AddWithValue("@searchTime", user.SearchTime);
                cmd.Parameters.AddWithValue("@searchWord", user.SearchWord);
                cmd.Parameters.AddWithValue("@anagram", user.Anagram);

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
