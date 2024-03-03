using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Entity.Concrete
{
    public class Card
    {
        public int Id { get; set; }

        public List<CardItem> CardItems { get; set; }
    }
}
