using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.InMemory;
using EntityLayer.Concrete;
using System.Text;

ProductManager product = new ProductManager(new MemoryProductDal());
foreach (Product products in product.GetAll())
{
    Console.WriteLine(products.ProductName);
}