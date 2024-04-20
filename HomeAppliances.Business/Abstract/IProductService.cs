using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetByIdWithBrands(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByBrand(string brand, int page, int pageSize);
        List<Product> GetProductsByCategoryId(int? categoryId);

        int GetCountByBrand(string brand);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
