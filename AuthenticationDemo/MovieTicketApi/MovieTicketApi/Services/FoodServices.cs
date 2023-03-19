using FoodieApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodieApi.Services
{
    public class FoodServices
    {
        private readonly IMongoCollection<Foods> foodcollection;
        public FoodServices(IOptions<DBSettings> dbSettings)
        {
            var foodConnection = new MongoClient(dbSettings.Value.ConnectionString);
            var foodb = foodConnection.GetDatabase(dbSettings.Value.DatabaseName);
            foodcollection = foodb.GetCollection<Foods>(dbSettings.Value.CollectionName);
        }

        //public async Task<List<Foods>> GetAsync()
        //    => await foodcollection.Find(_ => true).ToListAsync();


        public async Task<List<Foods>> GettheFood()
        {
            return await foodcollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertFoodDetails(Foods foods)
        {
            await foodcollection.InsertOneAsync(foods);
        }

        public async Task<Foods> GetById(string id)
        {
           return await foodcollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateFoodDetails(string id,Foods food)
        {
            await foodcollection.ReplaceOneAsync(x => x.Id == id, food);
        }

        public async Task DeleteFoodDetails(string id)
        {
            await foodcollection.DeleteOneAsync(x => x.Id == id);
        }

    }
}
