using WorkPathways.WorkPathways.DataAccess.Interfaces;
using MongoDB.Driver;
using WorkPathways.WorkPathways.Models;

namespace WorkPathways.WorkPathways.DataAccess.Services
{
    public class DesiredCompaniesDataAccessService : IDesiredComapniesDataAccessService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<DesiredCompanies> _collectionDesiredCompanies;
        private readonly IMongoDatabase _database;
        private readonly string dataBaseName = "GunasAppDataBase";
        public string collectionName = "DesiredComapniesCollection";

        public DesiredCompaniesDataAccessService(IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _mongoClient = new MongoClient(connectionString);
            _database=_mongoClient.GetDatabase(dataBaseName);
            _collectionDesiredCompanies=_database.GetCollection<DesiredCompanies>(collectionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desiredCompanies"></param>
        /// <returns></returns>
        public  async Task<List<DesiredCompanies>> AddDesiredCompanies(List<DesiredCompanies> desiredCompanies)
        {
            try
            {
                await _collectionDesiredCompanies.InsertManyAsync(desiredCompanies);
                return desiredCompanies;
            }
            catch (Exception ex) {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> DeleteDesiredCompanyByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<DesiredCompanies>.Filter.Eq(u => u.UserId, userId);
                var result = await _collectionDesiredCompanies.DeleteManyAsync(filter);

                if (result.DeletedCount > 0)
                {
                    return $"{result.DeletedCount} Desired Companies(s) deleted successfully.";
                }
                else
                {
                    throw new Exception("User has no Desired Companies to delete.");
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
        public async Task<List<DesiredCompanies>> GetDesiredCompanyByUserId(Guid userId)
        {
            try
            {
                var filter = Builders<DesiredCompanies>.Filter.Eq(u => u.UserId, userId);
                var desiredComapnies = await _collectionDesiredCompanies.Find(filter).ToListAsync();
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

        public async Task<string> UpdateDesiredCompany(DesiredCompanies desiredCompany)
        {
            try
            {
                var filter = Builders<DesiredCompanies>.Filter.Eq(u => u.Id, desiredCompany.Id);
                await _collectionDesiredCompanies.ReplaceOneAsync(filter, desiredCompany);
                return "Updated SuccessFully";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
