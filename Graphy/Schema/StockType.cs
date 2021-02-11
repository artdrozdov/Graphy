using GraphQL.Types;
using Graphy.Models;

namespace Graphy.Schema
{
    public class StockType: ObjectGraphType<Stock>
    {
        public StockType()
        {
            Field(x => x.Id);
            Field(x => x.Code);
            Field(x => x.Price);
            Field(x => x.CapturedAt);
        }   
    }
}