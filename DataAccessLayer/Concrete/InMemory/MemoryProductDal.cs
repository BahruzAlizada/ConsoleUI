using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.InMemory
{
    public class MemoryProductDal : IProductDal
    {
        List<Product> _products;
        public MemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitsInStock=3, UnitPrice=500},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitsInStock=2,UnitPrice=1500},
                new Product{ProductId=4,CategoryId=2,ProductName="Klaviatura",UnitsInStock=65, UnitPrice=150},
                new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitsInStock=1,UnitPrice=85},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x=>x.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x=>x.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product dbProduct = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            dbProduct.ProductName = product.ProductName;
            dbProduct.UnitPrice = product.UnitPrice;
            dbProduct.CategoryId=product.CategoryId;
            dbProduct.UnitsInStock= product.UnitsInStock;
        }
    }
}
