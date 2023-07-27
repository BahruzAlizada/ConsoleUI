using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System.Text;

ProductTest();

CategoryTest();

static void ProductTest()
{
    ProductManager product = new ProductManager(new EFProductDal());
    foreach (ProductDetailDto products in product.GetProductDetails().Data)
    {
        Console.WriteLine(products.ProductName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
    foreach (Category category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}