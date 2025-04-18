
namespace AudioVideoShop
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string Category { get; set; }
        public string Decription { get; set; }
        public string ImagePath { get; set; }

        public Product(string name, decimal price, string imagePath, bool inStock, string category, string decription)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            Category = category;
            Decription = decription;
            ImagePath = imagePath;
        }
    }
}
