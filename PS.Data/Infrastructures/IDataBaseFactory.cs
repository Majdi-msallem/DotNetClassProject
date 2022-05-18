using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public interface IDataBaseFactory:IDisposable
    {
     public    PSContext DataContext { get; }
    }
}
