﻿using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.DataAccess.Interfaces
{
    public interface IExperianceDataAccessService
    {
        public Task<List<Experiance>> AddExperiance(List<Experiance> experiance);
        public Task<List<Experiance>> GetExperianceByUserId(Guid userId);
        public Task<string> UpdateExperiance(Experiance experiance);
        public Task<string> DeleteExperianceByUserId(Guid userId);
    }
}
