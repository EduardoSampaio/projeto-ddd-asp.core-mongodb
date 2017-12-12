using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Controle.Imobilizado.Application.Models
{
    /// <summary>
    /// Model List Immobilized
    /// </summary>
    public class ImmobilizedViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public string Serial { get; set; }
        public bool Active { get; set; }
    }
}