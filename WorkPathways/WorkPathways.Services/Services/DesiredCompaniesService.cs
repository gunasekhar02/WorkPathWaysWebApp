using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Services;
using WorkPathways.WorkPathways.Models;
using System.Runtime.InteropServices;

namespace WorkPathways.WorkPathways.Services.Services
{
    public class DesiredCompaniesService:IDesiredCompaniesService
    {
        private readonly IDesiredComapniesDataAccessService _desiredComapniesDataAccessService;
        public DesiredCompaniesService(DesiredCompaniesDataAccessService desiredCompaniesDataAccessService) { 
            _desiredComapniesDataAccessService = desiredCompaniesDataAccessService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desiredCompanies"></param>
        /// <returns></returns>
        public async Task<List<DesiredCompanies>> AddDesiredCompanies(List<DesiredCompanies> desiredCompanies)
        {
            try
            {
                var response = await _desiredComapniesDataAccessService.AddDesiredCompanies(desiredCompanies);
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

        public async  Task<string> DeleteDesiredCompanyByUserId(Guid userId)
        {
            try
            {
                var response = await _desiredComapniesDataAccessService.DeleteDesiredCompanyByUserId(userId);
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
        public async Task<List<DesiredCompanies>> GetDesiredCompanyByUserId(Guid userId)
        {
            try
            {
                var response = await _desiredComapniesDataAccessService.GetDesiredCompanyByUserId(userId);
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
        /// <param name="desiredCompany"></param>
        /// <returns></returns>
        public async Task<string> UpdateDesiredCompany(DesiredCompanies desiredCompany)
        {
            try
            {
                var response = await _desiredComapniesDataAccessService.UpdateDesiredCompany(desiredCompany);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
