using MongoDB.Driver;
using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.DataAccess.Services
{
    public class UserDataAccessService: IUserDataAccessService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _collectionUser;
        private readonly string dataBaseName = "GunasAppDataBase";
        private readonly string collectionName = "UsersCollection";


        public UserDataAccessService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(dataBaseName);
            _collectionUser = _database.GetCollection<User>(collectionName);

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
                await _collectionUser.InsertOneAsync(user);
                return user;
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
                var filter = Builders<User>.Filter.Eq(u => u.UserId, user.UserId);
                var result = await _collectionUser.ReplaceOneAsync(filter, user);

                if (result.MatchedCount == 0)
                {
                    throw new Exception("User not found");
                }

                return "Successfully Updated the user details of " + user.FirstName;
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
        public async Task<string> DeleteUser(Guid userId)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                await _collectionUser.DeleteOneAsync(filter);
                return "Successfully Deleted the user details of " + Convert.ToString(userId);
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
        public async Task<User> GetUserById(Guid userId)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                var response = await _collectionUser.Find(filter).FirstOrDefaultAsync();
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
                var filter = Builders<User>.Filter.Regex(u => u.FirstName, new MongoDB.Bson.BsonRegularExpression(name, "i"));
                var response = await _collectionUser.Find(filter).FirstOrDefaultAsync();
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
                var response = await _collectionUser.Find(_ => true).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
