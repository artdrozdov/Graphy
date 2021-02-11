using System;
using GraphQL.Utilities;

namespace Graphy.Schema
{
    public class CompanySchema: GraphQL.Types.Schema
    {
        public CompanySchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<CompanyQuery>();
        }   
    }
}