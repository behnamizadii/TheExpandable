using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheExpandable.Entities;

namespace TheExpandable.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreDataContext _storeDbContext;

        public ItemRepository(StoreDataContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _storeDbContext.Items;
        }

        public Item GetItemById(string itemId)
        {
            var item =  _storeDbContext.Items.FirstOrDefault(i => i.ItemId == itemId);
            if(item == null) throw new NullReferenceException();
            return item;
        }
    }

    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(string itemId);
    }
}