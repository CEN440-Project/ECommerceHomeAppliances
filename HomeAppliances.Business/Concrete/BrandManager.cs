using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Concrete
{
    public class BrandManager
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Create(Brand entity)
        {
            _brandDal.Create(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
