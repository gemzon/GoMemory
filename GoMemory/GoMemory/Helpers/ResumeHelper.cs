using GoMemory.Models;
using System.Threading.Tasks;

namespace GoMemory.Helpers
{
    public static class ResumeHelper
    {
        public static async Task<ResumeModel> CheckResume(string playStyle)
        {
            return await App.ResumeRepository.GetResumeModel(playStyle);
        }

        public static void SetResume(ResumeModel resumeModel)
        {

            App.ResumeRepository.UpdateGameResume(resumeModel);
        }

        public static void RemoveResume(string playstyle)
        {
            App.ResumeRepository.RemoveResumeModel(playstyle);
        }
    }
}
