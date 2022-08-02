using Contracts;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BuisnessLogic;

namespace Anagram.Database
{
    public class DataBaseWordRepository : IWordRepository//gali naudpt web, gali naudot console.
    {
        private const string ConnectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

        public List<UserLogModel> GetUserLogInfo()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            // nuskaityti zodzius is lenteles
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            cmd.Connection = connection;

            cmd.CommandText = "SELECT UserIP, SearchTime, SearchWord, Anagram from UserLog";

            reader = cmd.ExecuteReader();

            List<UserLogModel> wordsList = new List<UserLogModel>();
            while (reader.Read())
            {
                var userLogModel = new UserLogModel();
                userLogModel.UserIP = reader.GetString(0);
                userLogModel.SearchTime = reader.GetDateTime(1);
                userLogModel.SearchWord = reader.GetString(2);
                userLogModel.Anagram = reader.GetString(3);

                wordsList.Add(userLogModel);
            }

            connection.Close();

            return wordsList;
        }
    }
}
