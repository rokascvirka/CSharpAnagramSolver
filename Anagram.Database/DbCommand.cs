namespace Anagram.Database
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
