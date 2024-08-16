using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.Services.Interfaces
{
    public interface IDesiredCompaniesService
    {
        public Task<List<DesiredCompanies>> AddDesiredCompanies(List<DesiredCompanies> desiredCompanies);
        public Task<List<DesiredCompanies>> GetDesiredCompanyByUserId(Guid userId);
        public Task<string> UpdateDesiredCompany(DesiredCompanies desiredCompany);
        public Task<string> DeleteDesiredCompanyByUserId(Guid userId);
    }
}
