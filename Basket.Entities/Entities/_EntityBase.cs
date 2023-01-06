using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Basket.Entities.Interfaces;

namespace Basket.Entities.Entities
{
    public class _EntityBase : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

    }
}
