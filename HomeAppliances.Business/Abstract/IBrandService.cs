using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface IBrandService
    {
        Brand GetById(int id);
        //Brand GetByIdWithProducts(int id);
        List<Brand> GetAll();
        void Create(Brand entity);
        void Update(Brand entity);
        void Delete(Brand entity);
    }
}
