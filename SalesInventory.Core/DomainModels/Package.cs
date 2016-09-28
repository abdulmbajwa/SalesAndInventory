namespace SalesInventory.Core.DomainModels
{
    public class Package : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
