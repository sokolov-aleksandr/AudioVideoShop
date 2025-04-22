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
            var existingItem = Items.FirstOrDefault(i => i.product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Count++; // увеличиваем количество
            }
            else
            {
                Items.Add(new CartItem { product = product, Count = 1 });
            }
        }

        public void RemoveItem(Product product)
        {
            var existingItem = Items.FirstOrDefault(i => i.product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Count--;

                if (existingItem.Count <= 0)
                {
                    Items.Remove(existingItem);
                }
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
