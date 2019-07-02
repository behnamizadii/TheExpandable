using System;
using System.Collections.Generic;
using System.Linq;
using TheExpandable.Entities;

namespace TheExpandable.DataAccess
{
    public interface IDBContext
    {
        IQueryable<Item> Items { get; }
    }

    public class DBContext : IDBContext
    {
        public IQueryable<Item> Items
        {
            get
            {
                return new List<Item>()
                {
                    new Item()
                    {
                        ItemId = "1",
                        Name = "Ipad Pencil",
                        Price = 110
                    },
                    new Item()
                    {
                        ItemId = "2",
                        Name = "Iphone Case",
                        Price = 20
                    },
                    new Item()
                    {
                        ItemId = "3",
                        Name = "Ipod Headphones",
                        Price = 35
                    },
                    new Item()
                    {
                        ItemId = "4",
                        Name = "JBL Speakers",
                        Price = 34
                    },
                    new Item()
                    {
                        ItemId = "5",
                        Name = "Airpods",
                        Price = 160
                    }
                }.AsQueryable();
            }
        }
    }
}