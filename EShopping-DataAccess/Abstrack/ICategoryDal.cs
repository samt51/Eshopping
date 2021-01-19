using System;
using EShopping_Entity;

namespace EShopping_DataAccess.Abstrack
{
    public interface ICategoryDal:IRepository<Category>
    {
       
        public Category GetByWithCategory(int id);
        void DeleteFromCategory(int categoryid, int productid);
    }
}
