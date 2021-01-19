using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EShopping_DataAccess.Abstrack
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetOne(Expression<Func<T, bool>> filter);
        T GetByID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
