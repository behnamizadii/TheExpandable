using GraphQL.Types;
using TheExpandable.Entities;

namespace TheExpandable.StoreApi.GraphQL.Types
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(I => I.ItemId);
            Field(I => I.Name);
            Field(I => I.Price);
        }
    }
}