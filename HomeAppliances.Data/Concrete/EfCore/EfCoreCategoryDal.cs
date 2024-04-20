using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HomeAppliances.Data.Concrete.EfCore
{
	public class EfCoreCategoryDal : EfCoreGenericRepository<ProductCategory, EfCoreContext>, ICategoryDal
	{
		public void DeleteFromProductCategory(int categoryId, int productId)
		{
			//
		}

		ProductCategory ICategoryDal.GetByIdWithProducts(int id)
		{
			using (var context = new EfCoreContext())
			{
				return context.ProductCategories
						.Where(i => i.ProductCategoryID == id)
						.FirstOrDefault();
			}
		}
	}
}
