using SQLite;

namespace GoMemory.DataAccess
{
   public class SqLiteConnection 
   {
      private readonly SQLiteAsyncConnection _conn;

       public SqLiteConnection(string dbPath)
       {
           _conn = new SQLiteAsyncConnection(dbPath);
       }
    }
}
