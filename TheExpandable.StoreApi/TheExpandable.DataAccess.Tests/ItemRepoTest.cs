using System;
using TheExpandable.Entities;
using Xunit;

namespace TheExpandable.DataAccess.Tests
{
    public class ItemRepoTest
    {
        private ItemRepo itemRepo;

        public ItemRepoTest()
        {
            itemRepo = new ItemRepo(new DBContext());
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