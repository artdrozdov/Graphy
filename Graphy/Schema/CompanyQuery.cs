using GraphQL.Types;
using Graphy.Services;

namespace Graphy.Schema
{
    public class CompanyQuery: ObjectGraphType
    {
        public CompanyQuery(ICompanyService companyService)
        {
            Name = "Query";
            Field<ListGraphType<CompanyType>>("companies", resolve: x => companyService.GetCompanies());
        }
    }
}