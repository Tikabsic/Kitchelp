
namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Warehouse? Warehouse { get; set; }
        public Guid WarehouseId { get; set; }
        public string? ProductName { get; set; }
        public float? Quantity { get; set; }
    }
}
