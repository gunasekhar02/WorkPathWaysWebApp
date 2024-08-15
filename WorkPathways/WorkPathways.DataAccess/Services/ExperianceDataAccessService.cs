using MongoDB.Driver;
using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.DataAccess.Interfaces;

namespace WorkPathways.WorkPathways.DataAccess.Services
{
    public class ExperianceDataAccessService:IExperianceDataAccessService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Experiance> _collectionExperiance;
        private readonly string dataBaseName = "GunasAppDataBase";
        private readonly string collectionName = "ExperianceCollection";


        public ExperianceDataAccessService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(dataBaseName);
            _collectionExperiance = _database.GetCollection<Experiance>(collectionName);
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
                await _collectionExperiance.InsertManyAsync(experiance);
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
                var filter = Builders<Experiance>.Filter.Eq(u => u.UserId, userId);
                var userExperiances = await _collectionExperiance.Find(filter).ToListAsync();
                return userExperiances;

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
        public async Task<string> UpdateExperiance(Experiance experiance)
        {
            try
            {
                var filter = Builders<Experiance>.Filter.Eq(u => u.Id, experiance.Id);
                await _collectionExperiance.ReplaceOneAsync(filter, experiance);
                return "updated Successfully";
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
                var filter = Builders<Experiance>.Filter.Eq(u => u.UserId, userId);
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
