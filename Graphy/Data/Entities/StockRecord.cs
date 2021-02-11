using System;

namespace Graphy.Data.Entities
{
    public class StockRecord
    {
        public long Id { get; set; } 
        public string Code { get; set; }
        public decimal Price { get; set; }
        public DateTime CapturedAt { get; set; }
    }
}