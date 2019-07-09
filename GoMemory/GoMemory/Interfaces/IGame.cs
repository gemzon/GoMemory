using GoMemory.Enums;

namespace GoMemory.Interfaces
{
    public interface IGame
    {
        bool NextRound();
        void InitilizeRound();
        void SetDifficultySettings(Difficulty difficulty);

        string SetLevelText();

        void Retry();
    }
}
