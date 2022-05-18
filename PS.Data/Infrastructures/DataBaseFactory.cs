using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        readonly PSContext dataContext;
        public PSContext DataContext =>  dataContext;

        public DataBaseFactory()
        {
            dataContext = new PSContext();
        }
        public override void DisposeCore()
        {
            DataContext.Dispose();
        }
    }
}
