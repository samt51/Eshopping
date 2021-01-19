using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EShopping_Entity;
namespace EShopping_DataAccess.Abstrack
{
    public interface IProductDal : IRepository<Products>
    {
      

        Products GetProductDetails(int id);
   
       List<Products> GetProductsByCategory(string categoryname);
        int GetCountByCategory(string categoryname);
        Products GetByIdWithCategory(int id);
        void Update(Products entity, int[] categoryıds);
    }
}
