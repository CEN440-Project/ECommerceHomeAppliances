using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Data.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetProductsByBrand(string brand, int page, int pageSize);
		List<Product> GetProductsByCategoryId(int? categoryId);

		Product GetProductDetails(int id);

        int GetCountByBrand(string brand);
        Product GetByIdWithBrands(int id);
    }
}
