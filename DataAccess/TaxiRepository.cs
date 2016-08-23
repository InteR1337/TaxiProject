using DataAccessInterfaces;
using DataModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TaxiRepository : IRepository<Taxi>
    {
        private MongoContext dbContext;

        public TaxiRepository(MongoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public void CreateEntity(Taxi entity)
        {
            var latestIdUsed = dbContext.Taxis.Find(new BsonDocument()).SortByDescending(x => x.Id).Project(x => x.Id).Limit(1).FirstOrDefault();
            latestIdUsed += 1;

            entity.Id = latestIdUsed;

            dbContext.Taxis.InsertOne(entity);
        }

        public void DeleteEntity(int id)
        {
            dbContext.Taxis.DeleteOne(x => x.Id == id);
        }

        public List<Taxi> GetEntities()
        {
            return dbContext.Taxis.Find(new BsonDocument()).ToList();
        }

        public Taxi GetEntity(int id)
        {
            return dbContext.Taxis.Find(x => x.Id == id).FirstOrDefault();
        }

        public void UpdatEntity(int id, Taxi entity)
        {
            dbContext.Taxis.ReplaceOne(x => x.Id == id, entity);
        }
    }
}
