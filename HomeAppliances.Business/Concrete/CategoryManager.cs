using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;

namespace HomeAppliances.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}
		public void Create(ProductCategory entity)
		{
			_categoryDal.Create(entity);
		}

		public void Delete(ProductCategory entity)
		{
			_categoryDal.Delete(entity);
		}

		public void DeleteFromProductCategory(int categoryId, int productId)
		{
			_categoryDal.DeleteFromProductCategory(categoryId, productId);
		}

		public List<ProductCategory> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public ProductCategory GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public ProductCategory GetByIdWithProducts(int id)
		{
			return _categoryDal.GetByIdWithProducts(id);
		}

		public void Update(ProductCategory entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
