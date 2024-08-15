using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Services;

namespace WorkPathways.WorkPathways.Services.Services
{
    public class ExperianceService: IExperianceService,IExperianceDataAccessService
    {
        private readonly IExperianceDataAccessService _experianceDataAccessService;
        public ExperianceService(ExperianceDataAccessService experianceDataAccess)
        {
            _experianceDataAccessService = experianceDataAccess;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="experiance"></param>
        /// <returns></returns>
        public async Task<List<Experiance>> AddExperiance(List<Experiance> experiance)
        {
            try
            {
                foreach (var exp in experiance)
                {
                    exp.Id = Guid.NewGuid();
                }
                var response = await _experianceDataAccessService.AddExperiance(experiance);  
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Experiance>> GetExperianceByUserId(Guid userId)
        {
            try
            {
                var response = await _experianceDataAccessService.GetExperianceByUserId(userId);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experiance"></param>
        /// <returns></returns>
        public async Task<string> UpdateExperiance(Experiance experiance)
        {
            try
            {
                var response = await _experianceDataAccessService.UpdateExperiance(experiance);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> DeleteExperianceByUserId(Guid userId)
        {
            try
            {
                var response = await _experianceDataAccessService.DeleteExperianceByUserId(userId);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
