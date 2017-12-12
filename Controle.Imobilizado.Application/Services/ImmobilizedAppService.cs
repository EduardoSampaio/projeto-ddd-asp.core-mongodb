using Controle.Imobilizado.Application.Interfaces;
using Controle.Imobilizado.Application.Models;
using Controle.Imobilizado.Domain.DomainEntities;
using Controle.Imobilizado.Domain.Interfaces;
using Controle.Imobilizado.Infra.Crosscutting.AssertionConcern;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace Controle.Imobilizado.Application.Services
{
    /// <summary>
    /// AppService Immobilized
    /// </summary>
    public class ImmobilizedAppService : Interfaces.IImmobilizedAppService
    {
        private readonly IImmobilizedRepository _repository;

        public ImmobilizedAppService(IImmobilizedRepository repository)
        {
            _repository = repository;
        }

        public void Delete(ObjectId id)
        {
            //Validation
            AssertionConcern.AssertArgumentNotNull(id, "O Id não pode ser vazio");

            _repository.Delete(id);
        }

        public IEnumerable<ImmobilizedViewModel> GetAll(int? skip = 0, int? limit = 50)
        {
            return _repository.GetAll(skip, limit)
                .Select(entity => new ImmobilizedViewModel
                {
                    Id = entity.Id.ToString(),
                    Title = entity.Title,
                    Description = entity.Description,
                    Localization = entity.Localization,
                    Serial = entity.Serial,
                    Active = entity.Active
                });
        }

        public ImmobilizedViewModel GetById(ObjectId id)
        {
            //Validation
            AssertionConcern.AssertArgumentNotNull(id, "O Id não pode ser vazio");

            var entity = _repository.GetById(id);
            return new ImmobilizedViewModel()
            {
                Id = entity.Id.ToString(),
                Title = entity.Title,
                Description = entity.Description,
                Localization = entity.Localization,
                Serial = entity.Serial,
                Active = entity.Active
            };
        }

        public void Create(ImmobilizedCreateCommand obj)
        {
            //Validation
            AssertionConcern.AssertArgumentNotEmpty(obj.Title, "O Titulo não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Localization, "O Localização não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Description, "O Descrição não pode ser vazio");
            AssertionConcern.AssertArgumentNotNull(obj.Active, "O Ativo não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Serial, "O Serial não pode ser vazio");
            AssertionConcern.AssertArgumentFalse(_repository.HasExists(obj.Serial), "Ja existe cadastro com esse serial");

            var entity = new Immobilized
                    (obj.Title, obj.Description, obj.Localization, obj.Active, obj.Serial);
            _repository.Save(entity);
        }

        public void Update(ImmobilizedUpdateCommand obj)
        {
            //Validation
            AssertionConcern.AssertArgumentNotEmpty(obj.Id, "O Id não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Title, "O Titulo não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Localization, "O Localização não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Description, "O Descrição não pode ser vazio");
            AssertionConcern.AssertArgumentNotNull(obj.Active, "O Ativo não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(obj.Serial, "O Serial não pode ser vazio");
            AssertionConcern.AssertArgumentFalse(_repository.HasExists(obj.Serial), "Ja existe cadastro com esse serial");

            var entity = new Immobilized
               (ObjectId.Parse(obj.Id), obj.Title, obj.Description, obj.Localization, obj.Active,obj.Serial);
            _repository.Update(entity);
        }
    }
}