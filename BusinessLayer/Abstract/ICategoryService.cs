using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IDataResult<Category> GetByName(string name);
        IResult Add(Category category);
        IResult Update(int id);
        IResult Delete(int id);
    }
}
