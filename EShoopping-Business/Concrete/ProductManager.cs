using System;
using System.Collections.Generic;
using EShopping_DataAccess;
using EShoopping_Business.Abstrack;
using EShopping_Entity;
using EShopping_DataAccess.Abstrack;

namespace EShoopping_Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Products entity)
        {
            if (Validate(entity))
            {
                _productDal.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Products entity)
        {
            _productDal.Delete(entity);
        }

        public List<Products> GetAll()
        {
            return _productDal.GetAll();
        }

       
        public Products GetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public Products GetByIdWithCategory(int id)
        {
            return _productDal.GetByIdWithCategory(id);
        }

        public int GetCountByCategory(string categoryname)
        {
            return _productDal.GetCountByCategory(categoryname);
        }

       public List<Products> GetProductByCategory(string categoryname)
        {
            return _productDal.GetProductsByCategory(categoryname);
        }
    

        public Products GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public void Update(Products entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Products entity, int[] categoryıds)
        {
            _productDal.Update(entity, categoryıds);
        }

        public bool Validate(Products entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.ProductName))
            {
                ErrorMessage += "Ürün İsmi Belirtiniz";
                isValid = false;
            }
            return isValid;
        }

        
    }
}
