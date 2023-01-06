namespace Basket.Entities.Entities
{
    public class TblItem : _EntityBase
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

    }
}
