using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Entity.Concrete
{
    public class CardItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Quantity { get; set; }
    }
}
