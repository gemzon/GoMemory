using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Models;

namespace GoMemory.Helpers
{
    public static class ResumeHelper
    {
        public static ResumeModel CheckResume(string playStyle)
        {
            return App.ResumeRepository.GetResumeModel(playStyle);
        }

        public static void SetResume(string playstyle, int level, int matchsNeeded,Difficulty difficulty)
        {
            ResumeModel resumeModel = new ResumeModel
            {
                Difficulty = difficulty,
                PlayStyle = playstyle,
                Level = level,
                MatchesNeeded = matchsNeeded
            };
            App.ResumeRepository.UpdateGameResume(resumeModel);
        }

        public static void RemoveResume(string playstyle)
        {
        App.ResumeRepository.RemoveResumeModel(playstyle);
        }
    }
}
