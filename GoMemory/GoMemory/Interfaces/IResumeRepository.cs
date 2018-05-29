using GoMemory.Models;
using SQLite;

namespace GoMemory.Interfaces
{
    public interface IResumeRepository
    {
        void UpdateGameResume(ResumeModel resumeModel);
        ResumeModel GetResumeModel(string playStyle);

        void RemoveResumeModel(string playStyle);
    }
}