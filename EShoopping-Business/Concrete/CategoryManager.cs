using System;
using System.Collections.Generic;
using EShoopping_Business.Abstrack;
using EShopping_DataAccess.Abstrack;
using EShopping_Entity;

namespace EShoopping_Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void DeleteFromCategory(int categoryid, int productid)
        {
            _categoryDal.DeleteFromCategory(categoryid, productid);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public Category GetByWithCategory(int id)
        {
            return _categoryDal.GetByWithCategory(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
