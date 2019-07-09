﻿using GoMemory.Models;
using System.Threading.Tasks;

namespace GoMemory.Interfaces
{
    public interface IResumeRepository
    {
        void UpdateGameResume(ResumeModel resumeModel);
        Task<ResumeModel> GetResumeModel(string playStyle);

        void RemoveResumeModel(string playStyle);
    }
}