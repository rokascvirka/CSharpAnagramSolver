using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Contracts;

namespace BuisnessLogic
{
    public class CachedWord : ICachedWord
    {
        public void AddCacheToServer(string input, string anagram)
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";


            if (input != null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (CheckForWordInCasheTable(input) == false)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO CashedWords(Words, Anagram) " + "VALUES(@words, @anagram)", connection);

                        cmd.Parameters.Add(new SqlParameter("@words", input));
                        cmd.Parameters.AddWithValue("@anagram", anagram);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }

            }
        }

        public bool CheckForWordInCasheTable(string input)
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand( $"SELECT Words FROM CashedWords WHERE Words='{input}'", connection); 
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    connection.Close(); //Do I really need this?
                    return true;
                }
                connection.Close(); //Do I really need this?
                return false;
            }

        }

        public string ReturnWordIfInCasheWords(string input)
        {

            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
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
                connection.Close();
            }
            return "No values";
        }
    }
}
