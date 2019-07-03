using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using TheExpandable.Entities;

namespace TheExpandable.DataAccess
{
    
    public class ItemRepo : IItemRepo
    {
        private IDBContext DbContext { get; set; }
        
        public ItemRepo(IDBContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public Item Get(string itemId)
        {
            var item = DbContext.Items.SingleOrDefault(i => i.ItemId == itemId);
            if(item == null) throw new NullReferenceException();

            return item;
        }

        public List<Item> GetAll()
        {
            var items = DbContext.Items.Where(i => i.ItemId != null).ToList();
            return items;
        }
    }

    public interface IItemRepo
    {
        Item Get(string itemId);
        List<Item> GetAll();
    }
}