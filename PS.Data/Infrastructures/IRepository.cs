using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PS.Data.Infrastructures
{
    public interface IRepository<T> where T : class 
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Delete(Expression<Func<T, bool>> condition);
        T GetById(int   id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null);
       // void Commit();
    }
}
