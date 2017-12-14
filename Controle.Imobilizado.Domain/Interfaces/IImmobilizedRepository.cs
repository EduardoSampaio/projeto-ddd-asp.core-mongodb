using Controle.Imobilizado.Domain.DomainEntities;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Controle.Imobilizado.Domain.Interfaces
{
    public interface IImmobilizedRepository
    {
        void Save(Immobilized obj);

        void Update(Immobilized obj);

        void Delete(ObjectId id);

        IEnumerable<Immobilized> GetAll(int skip = 0, int limit = 50);

        Immobilized GetById(ObjectId id);

        bool HasExists(string serial);
    }
}