namespace Graphy.Models
{
    public class Company
    {
        public Company(int id, string name, string description, long stockDataId)
        {
            Id = id;
            Name = name;
            Description = description;
            StockDataId = stockDataId;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long StockDataId { get; private set; }
    }
}