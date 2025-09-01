using DemoApitApp.Models;

namespace DemoApitApp.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 75000 },
            new Product { Id = 2, Name = "Mobile", Price = 25000 },
            new Product { Id = 3, Name = "Tablet", Price = 15000 }
        };
        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(int id, Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
