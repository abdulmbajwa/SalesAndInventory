namespace SalesInventory.Core.DomainModels
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string ProvinceId { get; set; }
    }
}
