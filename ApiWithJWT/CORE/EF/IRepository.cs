using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CORE.EF
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> Filter);

        int Insert(T model);
        int Update(T model);
        int Remove(Expression<Func<T, bool>> Filter);
        int RemoveByID(T model);
        int SaveChanges();

    }
}
