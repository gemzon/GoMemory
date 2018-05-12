using SQLite;

namespace GoMemory.Interfaces
{
   public interface ISQLiteConnection
   {
       SQLiteAsyncConnection GetConnection();
   }
}
