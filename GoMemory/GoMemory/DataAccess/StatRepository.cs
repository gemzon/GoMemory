using GoMemory.Enums;
using GoMemory.Interfaces;
using GoMemory.Models;
using SQLite;
using System;
using System.Collections.Generic;

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
            AsyncConnection.CreateTableAsync<ResumeModel>();
        }

        public async void UpdateGameStat(GameStat gameStat)
        {
            if (gameStat.Level == 0)
            {
                return;
            }

            GameStat stat;
            try
            {
                stat = await AsyncConnection.Table<GameStat>()
                    .FirstOrDefaultAsync(g => g.GameType == gameStat.GameType &&
                    g.Difficulty == gameStat.Difficulty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            if (stat != null && gameStat.Level <= stat.Level)
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

        public List<GameStat> GetGameStats(GameType gameType)
        {
            return SyncConnection.Table<GameStat>().Where(g => g.GameType == gameType).ToList();
        }
    }
}
