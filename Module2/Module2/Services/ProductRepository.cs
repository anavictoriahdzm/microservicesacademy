using Module2.Data;
using Module2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module2.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext productsDbContext;

        public ProductRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }      
        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.Id == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
