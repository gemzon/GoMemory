using System.Collections.Generic;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Models;

namespace GoMemory.Interfaces
{
    public interface IStatRepository
    {
        void UpadateGameStat(GameStat gameStat);
        Task<List<GameStat>> GetGameStats(string playStyle);
    }
}