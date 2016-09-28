using System.Collections.Generic;

namespace SalesInventory.Core.DomainModels
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNIC { get; set; }
        public int CityId { get; set; }
        public int SubscriberTypeId { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public City City { get; set; }
        public CustomerType CustomerType { get; set; }
        public List<SmartCard> SmartCards { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
