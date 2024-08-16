using MongoDB.Driver;
using WorkPathways.WorkPathways.DataAccess.Interfaces;
using WorkPathways.WorkPathways.Models;
namespace WorkPathways.WorkPathways.DataAccess.Services
{
    public class AccomplishmentsDataAccessService:IAccomplishmentsDataAccessService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<Accomplisments> _collectionAccomplishments;
        private readonly IMongoDatabase _database;
        private readonly string dataBaseName = "GunasAppDataBase";
        public string collectionName = "AccomplishmentsCollection";

        public AccomplishmentsDataAccessService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(dataBaseName);
            _collectionAccomplishments = _database.GetCollection<Accomplisments>(collectionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desiredCompanies"></param>
        /// <returns></returns>
        public async Task<List<Accomplisments>> AddAccomplishments(List<Accomplisments> accomplisments)
        {
            try
            {
                await _collectionAccomplishments.InsertManyAsync(accomplisments);
                return accomplisments;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> DeleteAccomplishmnetsByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<Accomplisments>.Filter.Eq(u => u.UserId, userId);
                var result = await _collectionAccomplishments.DeleteManyAsync(filter);

                if (result.DeletedCount > 0)
                {
                    return $"{result.DeletedCount} Accomplishment(s) deleted successfully.";
                }
                else
                {
                    throw new Exception("User has no Accomplishments to delete.");
                }
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
        public async Task<List<Accomplisments>> GetAccomplishmentsByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<Accomplisments>.Filter.Eq(u => u.UserId, userId);
                var desiredComapnies = await _collectionAccomplishments.Find(filter).ToListAsync();
                return desiredComapnies;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desiredCompany"></param>
        /// <returns></returns>

        public async Task<string> UpdateAccomplishment(Accomplisments accomplishment)
        {
            try
            {
                var filter = Builders<Accomplisments>.Filter.Eq(u => u.Id, accomplishment.Id);
                await _collectionAccomplishments.ReplaceOneAsync(filter, accomplishment);
                return "Updated SuccessFully";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
