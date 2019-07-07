using System;
using TheExpandable.Entities;
using Xunit;

namespace TheExpandable.DataAccess.Tests
{
    public class ItemRepositoryTest
    {
        private ItemRepository itemRepo;

        public ItemRepositoryTest()
        {
            itemRepo = new ItemRepository(new DBContext());
        }
        
        [Fact]
        public void GetItem_should_return_one_item()
        {
            var actual = itemRepo.Get("1");
            Assert.Equal("Ipad Pencil", actual.Name);
        }

        [Fact]
        public void GetItems_should_retun_all_items()
        {
            var actual = itemRepo.GetAll();
            Assert.Equal(5, actual.Count);
        }
    }
}