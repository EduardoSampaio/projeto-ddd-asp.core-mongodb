using Controle.Imobilizado.Domain.DomainEntities;
using Controle.Imobilizado.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Controle.Imobilizado.Infra.Data.Repository
{
    /// <summary>
    /// Repository Immobilized
    /// </summary>
    public class ImmobilizedRepository : IImmobilizedRepository
    {
        private readonly MongoContext _mongoContext;

        public ImmobilizedRepository()
        {
            _mongoContext = new MongoContext();
        }

        public void Save(Immobilized entity)
        {
            _mongoContext.Immobilized.InsertOne(entity);
        }

        public void Update(Immobilized entity)
        {
            _mongoContext.Immobilized.ReplaceOne(x => x.Id.Equals(entity.Id), entity);
        }

        public IEnumerable<Immobilized> GetAll(int? skip = 0, int? limit = 50)
        {
            return _mongoContext.Immobilized.Find(x => true).Skip(skip).Limit(limit).ToList();
        }

        public Immobilized GetById(ObjectId id)
        {
            return _mongoContext.Immobilized.Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {
            _mongoContext.Immobilized.DeleteOne(x => x.Id.Equals(id));
        }

        public bool HasExists(string serial)
        {
            return _mongoContext.Immobilized.Find(x => x.Serial.Equals(serial)).Any();
        }
    }
}