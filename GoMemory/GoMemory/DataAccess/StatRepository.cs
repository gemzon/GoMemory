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

        public readonly SQLiteAsyncConnection AsyncConnection;
        public SQLiteConnection SyncConnection;
        public StatRepository(string dbPath)
        {
            AsyncConnection = new SQLiteAsyncConnection(dbPath);
            SyncConnection = new SQLiteConnection(dbPath);
            AsyncConnection.CreateTableAsync<GameStat>();
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
                stat = await AsyncConnection.Table<GameStat>().FirstOrDefaultAsync(g => g.PlayStyle == gameStat.PlayStyle &&
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
                await AsyncConnection.InsertOrReplaceAsync(gameStat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<GameStat> GetGameStats(string playStyle)
        {
            return   SyncConnection.Table<GameStat>().Where(g => g.PlayStyle == playStyle).ToList();
        }
    }
}
