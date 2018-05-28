using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoMemory.DataAccess;
using GoMemory.Enums;
using GoMemory.Interfaces;
using GoMemory.Models;
using SQLite;

namespace GoMemory.DataAccess
{


    public class StatRepository : IStatRepository
    {

        private readonly SQLiteAsyncConnection _conn;

        public StatRepository(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);
            _conn.CreateTableAsync<GameStat>();
        }

        public async void UpadateGameStat(GameStat gameStat)
        {


            if (gameStat.Level == 0)
            {
                return;
            }

            GameStat stat;
            try
            {
                stat = await _conn.Table<GameStat>().FirstOrDefaultAsync(g => g.PlayStyle == gameStat.PlayStyle &&
                                                                                    g.Difficulty == gameStat.Difficulty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            if (stat == null || gameStat.Level <= stat.Level)
            {
                return;
            }

            try
            {
                await _conn.InsertOrReplaceAsync(gameStat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<List<GameStat>> GetGameStats(string playStyle)
        {
            try
            {
                return await _conn.Table<GameStat>().Where(g => g.PlayStyle == playStyle).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
