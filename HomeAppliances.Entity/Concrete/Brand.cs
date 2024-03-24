using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Entity.Concrete
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
