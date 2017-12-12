using Controle.Imobilizado.Domain.DomainEntities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace Controle.Imobilizado.Infra.Data
{
    /// <summary>
    /// Context Class MongoDB
    /// </summary>
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;
        public IConfigurationRoot Configuration { get; }

        public MongoContext()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);
        }

        public IMongoCollection<Immobilized> Immobilized
        {
            get
            {
                return database.GetCollection<Immobilized>("Immobilized");
            }
        }
    }
}