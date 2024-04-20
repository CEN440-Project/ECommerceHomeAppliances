using HomeAppliances.Entity.Concrete;

namespace HomeAppliances.Business.Abstract
{
	public interface ICategoryService
	{
		ProductCategory GetById(int id);
		ProductCategory GetByIdWithProducts(int id);
		List<ProductCategory> GetAll();
		void Create(ProductCategory entity);
		void Update(ProductCategory entity);
		void Delete(ProductCategory entity);
		void DeleteFromProductCategory(int categoryId, int productId);
	}
}
