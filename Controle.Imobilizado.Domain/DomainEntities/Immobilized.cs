using MongoDB.Bson;

namespace Controle.Imobilizado.Domain.DomainEntities
{
    /// <summary>
    /// Entity Immobilized
    /// </summary>
    public class Immobilized
    {
        public Immobilized(ObjectId id, string title, string description, string localization, bool active, string serial)
        {
            Id = id;
            Title = title;
            Description = description;
            Localization = localization;
            Active = active;
        }

        public Immobilized(string title, string description, string localization, bool active, string serial)
        {
            Title = title;
            Description = description;
            Localization = localization;
            Active = active;
            Serial = serial;
        }

        public ObjectId Id { get; private set; }
        public string Title { get; private set; }
        public string Serial { get; private set; }
        public string Description { get; private set; }
        public string Localization { get; private set; }
        public bool Active { get; private set; }
    }
}