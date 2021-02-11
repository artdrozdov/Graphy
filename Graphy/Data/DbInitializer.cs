using System;
using System.Linq;
using Graphy.Data.Entities;

namespace Graphy.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Stocks.Any()) return;

            var stocks = new StockRecord[]
            {
                new() {Code = "AAPL", Price = 137.09m, CapturedAt = DateTime.UtcNow},
                new() {Code = "MSFT", Price = 238.93m, CapturedAt = DateTime.UtcNow},
                new() {Code = "BLCKBRD", Price = 280.91m, CapturedAt = DateTime.UtcNow}
            };
            ctx.Stocks.AddRange(stocks);
            ctx.SaveChanges();

            var companies = new Company[]
            {
                new()
                {
                    Name = "Microsoft Corporation", StockData = stocks[1],
                    Description =
                        "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports, and sells computer software, consumer electronics, personal computers, and related services."
                },
                new()
                {
                    Name = "Apple Inc.", StockData = stocks[0],
                    Description =
                        "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, that designs, develops, and sells consumer electronics, computer software, and online services."
                },
                new()
                {
                    Name = "Blackbird Tech", StockData = stocks[2],
                    Description =
                        "Blackbird Tech is a provider of luxury software services headquartered in Kyiv, Ukraine."
                }
            };
            ctx.Companies.AddRange(companies);
            ctx.SaveChanges();
        } 
    }
}