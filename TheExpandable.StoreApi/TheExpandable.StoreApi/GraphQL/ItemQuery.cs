using GraphQL.Types;
using TheExpandable.DataAccess;
using TheExpandable.StoreApi.GraphQL.Types;

namespace TheExpandable.StoreApi.GraphQL
{
    public class ItemQuery : ObjectGraphType
    {
        public ItemQuery(ItemRepository itemRepository)
        {
            Field<ListGraphType<ItemType>>(
                "items", 
                resolve: context => itemRepository.GetAllItems()
            );
        }
    }
}