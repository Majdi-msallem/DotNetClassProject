using ProductStore.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork

    {
        IDataBaseFactory dbf;
        public UnitOfWork(IDataBaseFactory dbFactory) 
        { dbf = dbFactory; }
        public void Commit()
        {
            dbf.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            dbf.DataContext.Dispose();
        }

        public IRepository<T> getRepository<T>() where T : class
        {
            return new  Repository<T>(dbf);
        }
    }
}
