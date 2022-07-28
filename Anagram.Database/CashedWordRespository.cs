using Contracts;
using Contracts.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Anagram.Database
  
{
    public class CashedWordRespository : ICachedWordRepository
    {
        private const string ConnectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";
        public void AddCacheToServer(string input, string anagram)
        {
                using (var connection = new SqlConnection(ConnectionString))
                {
                var cashed = new CashedWordsModel();

                cashed.Words = input;
                cashed.Anagram = anagram;
                

                    connection.Open();
                    if (CheckForWordInCasheTable(cashed.Words) == false)
                    {
                        SqlCommand cmd = new SqlCommand($"INSERT INTO CashedWords(Words, Anagram) " + "VALUES(@words, @anagram)", connection);
                        
                        cmd.Parameters.Add(new SqlParameter("@words", cashed.Words));
                        cmd.Parameters.AddWithValue("@anagram", cashed.Anagram);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
        }

        public bool CheckForWordInCasheTable(string input)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand($"SELECT Words FROM CashedWords WHERE Words='{input}'", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    var result = true;
                    return result;
                }
                connection.Close();
            }
            return false;
        }

        public string ReturnWordIfInCasheWords(string input)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (CheckForWordInCasheTable(input) == true)
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Anagram From CashedWords Where Words = '{input}'", connection);
                    SqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    var text = reader.GetString(0);
                    connection.Close();

                    return text;

                }
                connection.Close(); // Keisti
            }
            return "No values";
        }
    }

    
}
