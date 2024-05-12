using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Data.Concrete.EfCore
{
    public class EfCoreAppUserDal : EfCoreGenericRepository<AppUser, EfCoreContext>, IAppUserDal
    {
    }
}
