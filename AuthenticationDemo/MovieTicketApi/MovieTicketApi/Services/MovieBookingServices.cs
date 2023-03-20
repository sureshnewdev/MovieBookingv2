using FoodieApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodieApi.Services
{
    public class MovieBookingServices
    {
        private readonly IMongoCollection<MovieTicket> mBcollection;
        public MovieBookingServices(IOptions<DBSettings> dbSettings)
        {
            var mBConnection = new MongoClient(dbSettings.Value.ConnectionString);
            var moviedb = mBConnection.GetDatabase(dbSettings.Value.DatabaseName);
            mBcollection = moviedb.GetCollection<MovieTicket>(dbSettings.Value.CollectionName);
        }

        //public async Task<List<Foods>> GetAsync()
        //    => await foodcollection.Find(_ => true).ToListAsync();


        public async Task<List<MovieTicket>> GetMovieTickets()
        {
            return await mBcollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertMovieTicket(MovieTicket movieTicket)
        {
            await mBcollection.InsertOneAsync(movieTicket);
        }

        public async Task<MovieTicket> GetById(string id)
        {
           return await mBcollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatemovieTicketDetails(string id,MovieTicket movieTicket)
        {
            await mBcollection.ReplaceOneAsync(x => x.Id == id, movieTicket);
        }

        public async Task DeleteMovieDetails(string id)
        {
            await mBcollection.DeleteOneAsync(x => x.Id == id);
        }

    }
}
