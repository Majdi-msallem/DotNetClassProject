using ProductStore.Data.Infrastructure;
using PS.Data;
using PS.Data.Infrastructures;
using PS.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
    public class CategoryService : Service<Category>,ICategoryService
    {
       
       readonly  IUnitOfWork utk;
       public CategoryService(IUnitOfWork utk) : base(utk) => this.utk = utk;

       
    }
}