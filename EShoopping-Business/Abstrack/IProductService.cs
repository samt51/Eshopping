using System;
using System.Collections.Generic;
using EShopping_Entity;
namespace EShoopping_Business.Abstrack
{
    public interface IProductService:IValidater<Products>
    {
        List<Products> GetAll();
        Products GetById(int id);
      
        bool Create(Products entity);
        void Update(Products entity);
        void Delete(Products entity);
        
        List<Products> GetProductByCategory(string categoryname);
        Products GetProductDetails(int id);
      
        int GetCountByCategory(string categoryname);
        Products GetByIdWithCategory(int id);
        void Update(Products entity, int[] categoryıds);
    }
}
