using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoShop
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; }
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(Product product)
        {
            // Проверяем, есть ли уже такой товар в корзине
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++; // увеличиваем количество
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveItem(Product product, int quantityToRemove = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                if (quantityToRemove >= existingItem.Quantity)
                {
                    Items.Remove(existingItem);
                }
                else
                {
                    existingItem.Quantity -= quantityToRemove;
                }
            }
        }


        public void Clear()
        {
            Items.Clear();
        }
    }
}
