using GraphQL;
using GraphQL.Types;

namespace TheExpandable.StoreApi.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ItemQuery>();
        }
    }
}