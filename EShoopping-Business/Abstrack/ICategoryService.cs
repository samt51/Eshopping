using System;
using System.Collections.Generic;
using EShopping_Entity;
namespace EShoopping_Business.Abstrack
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByWithCategory(int id);
        void DeleteFromCategory(int categoryid, int productid);
    }
}
