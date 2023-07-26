using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using EntityLayer.Concrete;
using System.Text;

ProductManager product = new ProductManager(new EFProductDal());
foreach (Product products in product.GetByUnitPrice(2,40))
{
    Console.WriteLine(products.ProductName);
}
