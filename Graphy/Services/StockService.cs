using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphy.Data;
using Graphy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Graphy.Services
{
    public class StockService: IStockService
    {
        private IServiceScopeFactory _serviceScopeFactory;

        public StockService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public async Task<Stock> GetStockByIdAsync(long id)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            var stock = await dataContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            return new Stock(stock.Id, stock.Code, stock.Price, stock.CapturedAt);
        }

        public Task<IEnumerable<Stock>> GetStocksAsync()
        {
            var scope = _serviceScopeFactory.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            var r = dataContext.Stocks.AsEnumerable().Select(x => new Stock(x.Id, x.Code, x.Price, x.CapturedAt));
            return Task.FromResult(r);
        }
    }

    public interface IStockService
    {
        Task<Stock> GetStockByIdAsync(long id);
        Task<IEnumerable<Stock>> GetStocksAsync();
    }
}