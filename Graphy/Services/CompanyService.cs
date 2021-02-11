using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphy.Data;
using Graphy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Graphy.Services
{
    public class CompanyService: ICompanyService
    {
        private IServiceScopeFactory _serviceScopeFactory;
        
        public CompanyService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        
        public Company GetCompanyById(int id)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            var record = dataContext.Companies.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                return new Company(record.Id, record.Name, record.Description, record.StockData.Id);
            }

            return default;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            
            var scope = _serviceScopeFactory.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            var record = await dataContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (record != null)
            {
                return new Company(record.Id, record.Name, record.Description, record.StockData.Id);
            }

            return default;
        }

        public Task<IEnumerable<Company>> GetCompanies()
        {
            
            var scope = _serviceScopeFactory.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            var records = dataContext.Companies.Select(x => new Company(x.Id, x.Name, x.Description, x.StockData.Id)).AsEnumerable();
            return Task.FromResult(records);

        }
    }

    public interface ICompanyService
    {
        Company GetCompanyById(int id);
        Task<Company> GetCompanyByIdAsync(int id);
        Task<IEnumerable<Company>> GetCompanies();
    }
}