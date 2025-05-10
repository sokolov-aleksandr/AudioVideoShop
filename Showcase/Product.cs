
namespace AudioVideoShop
{
    public class Product
    {
        public int Id { get; set; } // Заполняется отдельно
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Decription { get; set; }
        public string ImagePath { get; set; }

        public Product(string name, decimal price, string imagePath, int quantity, string category, string decription)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Decription = decription;
            ImagePath = imagePath;
        }
    }
}
