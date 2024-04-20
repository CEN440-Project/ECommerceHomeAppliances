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
    public class EfCoreProductDal : EfCoreGenericRepository<Product, EfCoreContext>, IProductDal
    {
        public Product GetByIdWithBrands(int id)
        {
            using (var context = new EfCoreContext())
            {
                return context.Products
                        .Where(i => i.BrandID == id)
                        .Include(i => i.Brand)
                        .FirstOrDefault();
            }
        }

        public int GetCountByBrand(string brand)
        {
            throw new NotImplementedException();
        }
        public Product GetProductDetails(int id)
        {
            using (var context = new EfCoreContext())
            {
                return context.Products
                            .Where(i => i.ProductID == id)
                            .Include(x => x.Brand)
                            .Include(y => y.ProductCategory)
                            .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByBrand(string brand, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

		public List<Product> GetProductsByCategoryId(int? categoryId)
		{
			using (var context = new EfCoreContext())
			{
				return context.Products
						.Where(i => i.CategoryID == categoryId)
						.Include(i => i.Brand)
						.ToList();
			}
		}
	}
}
