using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.DataAccess.Services;



namespace WorkPathways.WorkPathways.Services.Services
{
    public class UserService:IUserService,IUserDataAccessService
    {
        private readonly IUserDataAccessService  _userDataAccessService;
        public UserService(UserDataAccessService userDataAccessService) {
            _userDataAccessService = userDataAccessService;
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
                var response = await _userDataAccessService.CreateUser(user);
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
        public async Task<string> DeleteUser(Guid userId)
        {
            try
            {
                var response = await _userDataAccessService.DeleteUser(userId);
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
                var response = await _userDataAccessService.GetUserByFirstName(name);
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
                var response = await _userDataAccessService.GetUserById(id);
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
                var response = await _userDataAccessService.UpdateUser(user);
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
                var response = await _userDataAccessService.GetAllUsers();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
