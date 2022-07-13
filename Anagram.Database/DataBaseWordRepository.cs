using Contracts;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Data;

namespace Anagram.Database
{
    public class DataBaseWordRepository : IWordRepository //gali naudpt web, gali naudot console.
    {
        public HashSet<WordModel> GetWords()
        {
            //apsirasyti, ka grazins  /kodas kuris kreipiasi i duombaze ir sudeda i modelius.
            // atsidaryt duomenu baze
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            // nuskaityti zodzius is lenteles
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            cmd.Connection = connection;

            cmd.CommandText = "Select Word, Pronoun from Words";

            reader = cmd.ExecuteReader();

            HashSet<WordModel> wordsList = new HashSet<WordModel>();
            while (reader.Read())
            {
                var wordModel = new WordModel();
                wordModel.Word = reader.GetString(0);
                

                if (reader.GetValue(1) != DBNull.Value)
                {
                    wordModel.Pronoun = reader.GetString(1);
                }

                wordsList.Add(wordModel);
            }

            connection.Close();

            return wordsList;
        }
        public List<UserLogModel> GetUserLogInfo()
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
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
                userLogModel.SearchTime = reader.GetString(1);
                userLogModel.SearchWord = reader.GetString(2);
                userLogModel.Anagram = reader.GetString(3);

                wordsList.Add(userLogModel);
            }

            connection.Close();

            return wordsList;
        }
    }

}
