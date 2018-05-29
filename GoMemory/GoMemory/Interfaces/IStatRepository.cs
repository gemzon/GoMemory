using System.Collections.Generic;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Models;

namespace GoMemory.Interfaces
{
    public interface IStatRepository
    {
        void UpdateGameStat(GameStat gameStat);
        List<GameStat> GetGameStats(string playStyle);
    }
}