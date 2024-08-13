using MongoDB.Bson;
using WorkPathways.WorkPathways.Models;
namespace WorkPathways.WorkPathways.Services
{
    public interface IWorkPathwayService
    {
        public Task<User> CreateUser(User user);
        public Task<string> UpdateUser(User user);
        public Task<string> DeleteUser(Guid userId);
        public Task<User> GetUserById(Guid userId);
        public Task<User> GetUserByFirstName(string name);
        public Task<List<User>> GetAllUsers();


        // Experiance
        public Task<List<Experiance>>  AddExperiance(List<Experiance> experiance);
        public Task<List<Experiance>> GetExperianceByUserId(Guid userId);
        public Task<string> UpdateExperiance(List<Experiance> experiance);
        public Task<string> DeleteExperianceByUserId(Guid userId);


    }
}
