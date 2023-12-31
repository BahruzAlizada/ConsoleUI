﻿using BusinessLayer.Abstract;
using BusinessLayer.CCS;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.CrossCuttingConcerns.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.InMemory;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Business Code
              IResult result=  BusinessRules.Run(CheckIfCategoryProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExist(product.ProductName),CheckIfCategoryCountCorrect());

            if (result != null)
                return result;

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Business Code
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<Product> GetByID(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x=>x.UnitPrice>=min && x.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        #region Business Code
        private IResult CheckIfCategoryProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId).Count();
            if (result > 10)
                return new ErrorResult(Messages.ProductCountOfCategory);

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(x => x.ProductName == productName).Any();
             
            if (result)
                return new ErrorResult(Messages.ProductNameAlreadyExist);

            return new SuccessResult();
        }

        private IResult CheckIfCategoryCountCorrect()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.ProductCountOfCategory);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
