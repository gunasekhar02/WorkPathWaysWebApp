using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.DataAccess.Interfaces
{
    public interface IDesiredComapniesDataAccessService
    {
        public Task<List<DesiredCompanies>> AddDesiredCompanies(List<DesiredCompanies> desiredCompanies);
        public Task<List<DesiredCompanies>> GetDesiredCompanyByUserId(Guid userId);
        public Task<string> UpdateDesiredCompany(DesiredCompanies desiredCompany);
        public Task<string> DeleteDesiredCompanyByUserId(Guid userId);
    }
}
