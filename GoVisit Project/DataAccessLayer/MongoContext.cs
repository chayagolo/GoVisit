using GoVisit_Project.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GoVisit_Project.DAL
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;
        public IMongoCollection<AppointmentModel> Appointments => _database.GetCollection<AppointmentModel>("Appointments");

        public MongoContext(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase("GoVisitDB");
        }
    }
}
