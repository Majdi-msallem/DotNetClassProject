using ProductStore.Data.Infrastructure;
using PS.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PS.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork utk;
        IRepository<T> repo;
        public Service(IUnitOfWork utk)
        {
            this.utk = utk;
            repo = utk.getRepository<T>();
        }

        public void Commit()
        {
            utk.Commit();
        }
        public void Dispose()
        {
            utk.Dispose();
        }
        public virtual void Add(T entity)
        {
            repo.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            repo.Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            repo.Delete(where);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return repo.Get(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public virtual T GetById(int  Id)
        {
            return repo.GetById(Id);
        }

        public virtual T GetById(string Id)
        {
            return repo.GetById(Id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            return repo.GetMany(where);
        }

        public virtual void Update(T entity)
        {
            repo.Update(entity);
        }
    }
}
