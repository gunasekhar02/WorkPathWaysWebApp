using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Services;
using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;

namespace WorkPathways.WorkPathways.Services.Services
{
    public class AccomplishmentsService : IAccomplishmentsService
    {
        private readonly IAccomplishmentsDataAccessService _accomplishmentsDataAccessService;
        public AccomplishmentsService(AccomplishmentsDataAccessService accomplishmentsDataAccessService) {
            _accomplishmentsDataAccessService = accomplishmentsDataAccessService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accomplishments"></param>
        /// <returns></returns>
        public async Task<List<Accomplisments>> AddAccomplishments(List<Accomplisments> accomplishments)
        {
            try
            {
                var response = await _accomplishmentsDataAccessService.AddAccomplishments(accomplishments);
                return response;
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async  Task<string> DeleteAccomplishmnetsByUserId(Guid userId)
        {
            try
            {
                var response = await _accomplishmentsDataAccessService.DeleteAccomplishmnetsByUserId(userId);
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async  Task<List<Accomplisments>> GetAccomplishmentsByUserId(Guid userId)
        {
            try
            {
                var response = await _accomplishmentsDataAccessService.GetAccomplishmentsByUserId(userId);
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns></returns>
        public async Task<string> UpdateAccomplishment(Accomplisments accomplishment)
        {
            try
            {
                var response = await _accomplishmentsDataAccessService.UpdateAccomplishment(accomplishment);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
