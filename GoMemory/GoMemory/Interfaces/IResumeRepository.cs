using System.Threading.Tasks;
using GoMemory.Models;
using SQLite;

namespace GoMemory.Interfaces
{
    public interface IResumeRepository
    {
        void UpdateGameResume(ResumeModel resumeModel);
        Task<ResumeModel> GetResumeModel(string playStyle);

        void RemoveResumeModel(string playStyle);
    }
}