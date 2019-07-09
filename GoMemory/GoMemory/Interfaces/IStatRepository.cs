using GoMemory.Models;
using System.Collections.Generic;

namespace GoMemory.Interfaces
{
    public interface IStatRepository
    {
        void UpdateGameStat(GameStat gameStat);
        List<GameStat> GetGameStats(string playStyle);
    }
}