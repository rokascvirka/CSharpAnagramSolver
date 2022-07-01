namespace Anagram.Database
{
    internal partial class Program
    {
        public class SqlConnections : DbConnection
        {
            public SqlConnections(string connection) : base(connection)
            {
            }

            public override void Open()
            {

            }

            public override void Close()
            {
            }
        }
    }
}
