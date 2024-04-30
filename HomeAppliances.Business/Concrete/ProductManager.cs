using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Data.Concrete.EfCore;
using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public bool Create(Product entity)
        {
            if (Validate(entity))
            {
                _productDal.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByIdWithBrands(int id)
        {
            return _productDal.GetByIdWithBrands(id);
        }

        public int GetCountByBrand(int brand)
        {
            return _productDal.GetCountByBrand(brand);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByBrand(int brand, int page, int pageSize)
        {
            return _productDal.GetProductsByBrand(brand, page, pageSize);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public string ErrorMessage { get; set; }

        public bool Validate(Product entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz";
                isValid = false;
            }

            return isValid;
        }

		public List<Product> GetProductsByCategoryId(int? categoryId)
		{
            return _productDal.GetProductsByCategoryId(categoryId);
		}

		public List<Product> GetProductsWithBrand()
		{
			return _productDal.GetProductsWithBrand();
		}
	}
}
