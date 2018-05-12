using SQLite;

namespace GoMemory.Interfaces
{
    public class SQLiteConnection
    {
        private readonly SQLiteAsyncConnection _conn;

        public SQLiteConnection(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);
        }
    }
}
