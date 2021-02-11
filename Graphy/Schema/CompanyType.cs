using GraphQL.Types;
using Graphy.Models;
using Graphy.Services;

namespace Graphy.Schema
{
    public class CompanyType: ObjectGraphType<Company>
    {
        public CompanyType(IStockService stockService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field<StockType>("stock", resolve:x => stockService.GetStockByIdAsync(x.Source.StockDataId));
        }
    }
}