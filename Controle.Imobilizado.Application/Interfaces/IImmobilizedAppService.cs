using Controle.Imobilizado.Application.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Controle.Imobilizado.Application.Interfaces
{
    public interface IImmobilizedAppService
    {
        void Create(ImmobilizedCreateCommand obj);

        void Update(ImmobilizedUpdateCommand obj);

        void Delete(ObjectId id);

        IEnumerable<ImmobilizedViewModel> GetAll(int? skip = 0, int? limit = 50);

        ImmobilizedViewModel GetById(ObjectId id);
    }
}