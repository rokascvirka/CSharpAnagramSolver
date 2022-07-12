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
        private readonly string _connectionString;


        public CachedWord()
        {

        }

        public void AddCacheToServer(string input, string anagram)
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";


            if (input != null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO CashedWords(Words, Anagram) " + "VALUES(@words, @anagram)", connection);

                    cmd.Parameters.Add(new SqlParameter("@words", input));
                    cmd.Parameters.AddWithValue("@anagram", anagram);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }

            }
        }

        public List<string> CheckForWordInCasheTable(string input)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT Words, Anagram FROM CachedWords WHERE Words=" + input, connection);
            }




            var list = new List<string>();
            return list;
        }
    }
}
