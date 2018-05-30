using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Interfaces;
using GoMemory.Models;
using SQLite;

namespace GoMemory.DataAccess
{
    public class ResumeRepository : IResumeRepository
    {

        public SQLiteAsyncConnection AsyncConnection;
        public SQLiteConnection Conn;
        public ResumeRepository(string dbPath)
        {

            Conn = new SQLiteConnection(dbPath);
            AsyncConnection = new SQLiteAsyncConnection(dbPath);
            AsyncConnection.CreateTableAsync<ResumeModel>();
           
        }

        public async void UpdateGameResume(ResumeModel resumeModel)
        {
            if (resumeModel.Level == 0)
            {
                return;
            }
      
            try
            {
               await AsyncConnection.InsertOrReplaceAsync(resumeModel);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void RemoveResumeModel(string playStyle)
        {
            try
            {
                Conn.Table<ResumeModel>().Delete(g => g.PlayStyle == playStyle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public ResumeModel GetResumeModel(string playStyle)
        {
            ResumeModel resume = null;
            try
            {
                resume = Conn.Table<ResumeModel>().FirstOrDefault(g => g.PlayStyle == playStyle);
        
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return resume;
        }
    }
}