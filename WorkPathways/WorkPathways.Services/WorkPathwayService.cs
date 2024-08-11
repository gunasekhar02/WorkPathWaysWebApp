using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services;
using WorkPathways.WorkPathways.DataAccess;
using MongoDB.Bson;
namespace WorkPathways.WorkPathways.Services
{
    public class WorkPathwayService : IWorkPathwayService,IWorkPathwaysDataAccessService
    {
        private readonly IWorkPathwaysDataAccessService _dataAccessService;
        public WorkPathwayService(WorkPathwaysDataAccessService workPathwaysDataAccessService) { 
            _dataAccessService = workPathwaysDataAccessService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateUser(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                var response = await _dataAccessService.CreateUser(user);
                return response;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public async Task<string> DeleteUser(Guid userId)
        {
            try
            {
                var response = await _dataAccessService.DeleteUser(userId);
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
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<User> GetUserByFirstName(string name)
        {
            try
            {
                var response = await _dataAccessService.GetUserByFirstName(name);
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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var response = await _dataAccessService.GetUserById(id);
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
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> UpdateUser(User user)
        {
            try
            {
                var response = await _dataAccessService.UpdateUser(user);
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
        /// <returns></returns>
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await _dataAccessService.GetAllUsers();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
