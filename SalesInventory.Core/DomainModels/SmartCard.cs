using System;

namespace SalesInventory.Core.DomainModels
{
    public class SmartCard : BaseEntity
    {
        public string CardNumber { get; set; }
        public int MasterCardId { get; set; }
        public int SubscriberId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SmartCardStatusId { get; set; }
        public string CardSort { get; set; }
        public int BatchId { get; set; }
    }
}
