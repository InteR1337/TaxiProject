using DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MongoContext
    {
        private const string DATABASE_NAME = "taxidb";
        private const string CONNECTION_STRING_NAME = "taxidbconstr";

        private const string TAXI_COLLECTION_NAME = "taxis";
        private const string ORDER_COLLECTION_NAME = "orders";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Taxi> Taxis
        {
            get { return _database.GetCollection<Taxi>(TAXI_COLLECTION_NAME); }
        }

        public IMongoCollection<TaxiOrder> TaxiOrders
        {
            get { return _database.GetCollection<TaxiOrder>(ORDER_COLLECTION_NAME); }
        }
    }
}
