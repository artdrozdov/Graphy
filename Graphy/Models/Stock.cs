using System;

namespace Graphy.Models
{
    public class Stock
    {
        public Stock(long id, string code, decimal price, DateTime created)
        {
            Id = id;
            Code = code;
            Price = price;
            CapturedAt = created;
        }
        public long Id { get; set; } 
        public string Code { get; set; }
        public decimal Price { get; set; }
        public DateTime CapturedAt { get; private set; }
    }
}