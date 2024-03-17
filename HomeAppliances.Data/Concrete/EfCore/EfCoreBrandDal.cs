using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Data.Concrete.EfCore
{
    public class EfCoreBrandDal : EfCoreGenericRepository<Brand, Context>, IBrandDal
    {
        //
    }
}
