using HomeAppliances.Entity.Concrete;namespace HomeAppliances.Data.Abstract
{
	public interface ICategoryDal : IRepository<ProductCategory>
	{
		ProductCategory GetByIdWithProducts(int id);
		void DeleteFromProductCategory(int categoryId, int productId);
	}
}
