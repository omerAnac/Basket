using MongoDB.Bson;

namespace Basket.Entities.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}
