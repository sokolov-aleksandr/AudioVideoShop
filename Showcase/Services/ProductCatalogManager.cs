using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop.Services
{
    /// <summary>
    /// Вся логика работы с панелью каталога: 
    /// - загрузка товаров из БД
    /// - создание карточек
    /// - фильтрация по категории
    /// - добавление/удаление/обновление одной карточки
    /// </summary>
    public class ProductCatalogManager : IDisposable
    {
        private readonly ProductsDataSource _productsData;
        private readonly FlowLayoutPanel _panel;

        public ProductCatalogManager(ProductsDataSource productsData, FlowLayoutPanel panel)
        {
            _productsData = productsData ?? throw new ArgumentNullException(nameof(productsData));
            _panel = panel ?? throw new ArgumentNullException(nameof(panel));
        }

        /// <summary>
        /// Загружает все продукты из БД и отрисовывает их
        /// </summary>
        public void UpdateCatalogFromDatabase()
        {
            var products = _productsData.LoadProducts();
            RenderCatalog(products);
        }

        /// <summary>
        /// Рисует заданный список продуктов в панели
        /// </summary>
        /// <param name="products">Список продуктов для рендера</param>
        private void RenderCatalog(IEnumerable<Product> products)
        {
            _panel.Controls.Clear();
            foreach (var p in products)
            {
                var card = CreateCard(p);
                _panel.Controls.Add(card);
            }
        }

        /// <summary>
        /// Добавляет одну карточку (визуально) и сохраняет продукт в БД
        /// </summary>
        /// <param name="product">Новый продукт</param>
        public void CreateProductCard(Product product)
        {
            _productsData.AddProductToDB(product);
            var card = CreateCard(product);
            _panel.Controls.Add(card);
        }

        /// <summary>
        /// Обновляет существующий продукт в БД и перерисовывает весь каталог
        /// </summary>
        /// <param name="product">Продукт для обновления</param>
        public void UpdateProduct(Product product)
        {
            _productsData.UpdateProductInDB(product);
            UpdateCatalogFromDatabase();
        }

        /// <summary>
        /// Удаляет продукт по id: сначала из БД, потом находит и удаляет визуальную карточку
        /// </summary>
        /// <param name="productId">Id продукта для удаления</param>
        public void DeleteProduct(int productId)
        {
            _productsData.DeleteProductById(productId);

            // Удаляем визуальную карточку, если она есть:
            foreach (Control ctrl in _panel.Controls)
            {
                if (ctrl is ProductCard card && card.Product.Id == productId)
                {
                    _panel.Controls.Remove(card);
                    card.Dispose();
                    break;
                }
            }
        }

        /// <summary>
        /// Фильтрует товары по категории
        /// </summary>
        /// <param name="category">Имя категории</param>
        public void FilterByCategory(string category)
        {
            var all = _productsData.LoadProducts();
            if (string.Equals(category, "Все", StringComparison.OrdinalIgnoreCase))
            {
                RenderCatalog(all);
            }
            else
            {
                var filtered = all.Where(p => p.Category == category).ToList();
                RenderCatalog(filtered);
            }
        }

        /// <summary>
        /// «Фабрика» для создания одного ProductCard
        /// </summary>
        private ProductCard CreateCard(Product p)
        {
            var card = new ProductCard(null, p);
            // Здесь мы передаём null в конструктор, потому что форму-родитель мы не используем внутри ProductCard
            card.SetProduct(p);
            return card;
        }

        public void Dispose()
        {
            _productsData?.Dispose();
        }
    }
}
