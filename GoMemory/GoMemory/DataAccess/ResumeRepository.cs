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

        public SQLiteAsyncConnection Conn;
       
        public ResumeRepository(string dbPath)
        {

        
           Conn= new SQLiteAsyncConnection(dbPath);
            Conn.CreateTableAsync<ResumeModel>();
           
        }

        public async void UpdateGameResume(ResumeModel resumeModel)
        {
            if (resumeModel.Level == 0)
            {
                return;
            }
      
            try
            {
               await Conn.InsertOrReplaceAsync(resumeModel);
               
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
                Conn.Table<ResumeModel>().DeleteAsync(g => g.PlayStyle == playStyle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<ResumeModel> GetResumeModel(string playStyle)
        {
            ResumeModel resume = null;
            try
            {
                resume = await Conn.Table<ResumeModel>().FirstOrDefaultAsync(g => g.PlayStyle == playStyle);
        
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