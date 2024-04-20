using HomeAppliances.Entity.Concrete;

namespace HomeAppliances.WebUI.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
		public string SelectedCategory { get; set; }
	}
}
