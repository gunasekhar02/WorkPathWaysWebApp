using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.Services.Interfaces
{
    public interface IAccomplishmentsService
    {
        public Task<List<Accomplisments>> AddAccomplishments(List<Accomplisments> accomplishments);
        public Task<List<Accomplisments>> GetAccomplishmentsByUserId(Guid userId);
        public Task<string> UpdateAccomplishment(Accomplisments Accomplishment);
        public Task<string> DeleteAccomplishmnetsByUserId(Guid userId);
    }
}
