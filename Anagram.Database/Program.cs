using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;

namespace Anagram.Database
{
    
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //SqlConnectionas
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";
            var txtFilePath = ("C:\\Users\\rokas.cvirka\\Documents\\zodynas3.txt");

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            //sql commands

            
            using (var streamReader = new StreamReader(txtFilePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {

                    string[] fields = line.Split("\t");
                    

                    SqlCommand command = new SqlCommand("INSERT INTO Words(Word, Pronoun) " + "VALUES(@word, @pronoun)", connection);

                    if (fields.Length == 1)
                    {
                        command.Parameters.AddWithValue("@word", fields[0]);
                        command.Parameters.AddWithValue("@pronoun", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@word", fields[0]);
                        command.Parameters.AddWithValue("@pronoun", fields[1]);
                    }
                    



                    command.ExecuteNonQuery();
                }
            }

            connection.Close();

            var data = new DataBaseWordRepository();

            var hsetas = data.GetWords();

            connection.Close();
        }
    }
}
