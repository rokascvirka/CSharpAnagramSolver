namespace Anagram.Database
{
    internal partial class Program
    {
        public class DbCommand
        {
            private readonly DbConnection _connection;

        public DbCommand(DbConnection connection)
            {
                _connection = connection;
            }
        }
    }
}
