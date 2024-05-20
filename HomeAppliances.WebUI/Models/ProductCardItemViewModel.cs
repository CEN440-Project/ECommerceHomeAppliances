using HomeAppliances.Entity.Concrete;

namespace HomeAppliances.WebUI.Models
{
    public class ProductCardItemViewModel
    {
        public Product Product { get; set; }
        public CardItem CardItem { get; set; }
        public List<Product> LastProducts { get; set; }
    }
}
