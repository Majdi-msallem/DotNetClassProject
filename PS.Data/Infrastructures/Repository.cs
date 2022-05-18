using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PS.Data.Infrastructures
{
  public   class Repository<T> : IRepository<T> where T : class
    {
        IDataBaseFactory dbf;
        DbSet<T> dbset;

        public Repository(IDataBaseFactory dbf )
        {
            this.dbf = dbf;
            dbset = dbf.DataContext.Set<T>();       
        }
        public void Add(T obj)
        {
            dbset.Add(obj);
            
        }

      //  public void Commit()
       // {
         //   dbf.DataContext.SaveChanges();
        //}

        public void Delete(T obj)
        {
            dbset.Remove(obj);
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
             dbset.RemoveRange(dbset.Where(condition));
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return dbset.Where(condition).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
                return  
                dbset.AsEnumerable();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T GetById(string id)
        {
            return dbset.Find(id);
        }

      

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null)
        {
            if (condition!= null)
                return dbset.Where(condition).AsEnumerable();
            return dbset.AsEnumerable();
        }

        public void Update(T obj)
        {
            dbset.Update(obj);
        }
    }
}
