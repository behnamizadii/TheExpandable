using System.Linq;
using TheExpandable.Entities;

namespace TheExpandable.DataAccess
{
    public class BasketRepository : IBasketRepository
    {
        private Basket Basket;
        private IItemRepository _itemRepository;
        
        public BasketRepository(Basket basket, IItemRepository itemRepository)
        {
            Basket = basket;
            _itemRepository = itemRepository;
        }

        public Basket Add(string itemId)
        {
            var item = _itemRepository.GetItemById(itemId);
            Basket.Items.Add(item);
            CalculateTotalPrice();
            return Basket;
        }

        public Basket Remove(string itemId)
        {
            var item = _itemRepository.GetItemById(itemId);
            Basket.Items.Remove(item);
            CalculateTotalPrice();
            return Basket;
        }

        public void CalculateTotalPrice()
        {
            Basket.TotalPrice = Basket.Items.Sum(basketItem => basketItem.Price);
        }
    }

    public interface IBasketRepository
    {
        Basket Add(string itemId);
        Basket Remove(string itemId);
    }
    
}