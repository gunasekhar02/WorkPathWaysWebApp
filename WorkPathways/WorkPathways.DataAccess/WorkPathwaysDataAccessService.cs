using WorkPathways.WorkPathways.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections;
using Microsoft.Extensions.Configuration;

namespace WorkPathways.WorkPathways.DataAccess
{
    public class WorkPathwaysDataAccessService: IWorkPathwaysDataAccessService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _collectionUser;
        private readonly IMongoCollection<Experiance> _collectionExperiance;
        private readonly IMongoCollection<DesiredCompanies> _collectionDesiredCompanies;
        private readonly IMongoCollection<Accomplisments> _collectionAccomplisments;
        private readonly string dataBaseName = "GunasAppDataBase";
        private readonly string collectionName = "WorkPathwaysCollection";


        public WorkPathwaysDataAccessService( IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _mongoClient=new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(dataBaseName);
            _collectionUser = _database.GetCollection<User>(collectionName);
            _collectionAccomplisments= _database.GetCollection<Accomplisments>(collectionName);
            _collectionDesiredCompanies = _database.GetCollection<DesiredCompanies>(collectionName);
            _collectionExperiance = _database.GetCollection<Experiance>(collectionName);
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
            catch (Exception ex) {
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

                return "Successfully Updated the user details of "+ user.FirstName;
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
            catch (Exception ex) {
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
                var response = await _collectionUser.Find(_=>true).ToListAsync();
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
        /// <param name="experiance"></param>
        /// <returns></returns>
        public async Task<List<Experiance>> AddExperiance(List<Experiance> experiance)
        {
            try
            {
                var userId = experiance[0].Id;
                var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                var user = await _collectionUser.Find(filter).FirstOrDefaultAsync();
                if (user.Experiance?.Count==0)
                {
                    user.Experiance = new List<Experiance>();
                    foreach(var exp in experiance)
                    {
                        user.Experiance.Add(exp);
                    }
                }
                else
                {
                    foreach (var exp in experiance)
                    {
                        user.Experiance?.Add(exp);
                    }
                }
                await UpdateUser(user);
                return experiance;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Experiance>> GetExperianceByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                var user = await _collectionUser.Find(filter).FirstOrDefaultAsync();
                if (user.Experiance?.Count > 0) 
                {
                    return user.Experiance;
                }
                else
                {
                    throw new Exception("User has No Experiance");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experiance"></param>
        /// <returns></returns>
        public async Task<string> UpdateExperiance(List<Experiance> experiance)
        {
            try
            {
                var userId = experiance[0].Id;
                var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                var user = await _collectionUser.Find(filter).FirstOrDefaultAsync();
                if (user.Experiance?.Count > 0)
                {
                    user.Experiance = experiance;
                    return "updated Experiance Successfully";
                }
                else
                {
                    throw new Exception("User has No Experiance to update");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> DeleteExperianceByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<Experiance>.Filter.Eq(u => u.Id, userId);
                // Delete experiences associated with the userId
                var result = await _collectionExperiance.DeleteManyAsync(filter);

                if (result.DeletedCount > 0)
                {
                    return $"{result.DeletedCount} experience(s) deleted successfully.";
                }
                else
                {
                    throw new Exception("User has no experience to delete.");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
