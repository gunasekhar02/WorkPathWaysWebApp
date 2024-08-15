using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<string> UpdateUser(User user);
        public Task<string> DeleteUser(Guid userId);
        public Task<User> GetUserById(Guid userId);
        public Task<User> GetUserByFirstName(string name);
        public Task<List<User>> GetAllUsers();
    }
}
