using HomeAppliances.Entity.Concrete;

namespace HomeAppliances.WebUI.Models
{
    public class CheckoutViewModel
    {
        public List<CardItem> CardItems { get; set; }
        public AppUser AppUser { get; set; }
        public OrderItem OrderItem { get; set; }
        public Order Order { get; set; }


    }
}
