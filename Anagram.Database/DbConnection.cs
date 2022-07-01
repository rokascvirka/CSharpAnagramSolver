namespace Anagram.Database
{
    public abstract class DbConnection
    {
        private string _connectionString { get; set; }

        public DbConnection(string connection)
        {
            _connectionString = connection;
        }

        public abstract void Open();
        public abstract void Close();
    }
}
