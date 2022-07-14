using System.Data.SqlClient;

namespace BuisnessLogic
{
    public class ClearDataBaseService
    {
        public void EmptyCashedWordsTable()
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE CashWords");
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EmptyWordsTable()
        {
            var connectionString = "Server=LT-LIT-SC-0684\\MSSQLSERVER01;Database=Words; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE Words");
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
