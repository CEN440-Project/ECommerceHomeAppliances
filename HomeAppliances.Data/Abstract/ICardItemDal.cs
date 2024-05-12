using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Data.Abstract
{
    public interface ICardItemDal : IRepository<CardItem>
    {
        List<CardItem> GetCardItemsWithProducts();
        List<CardItem> GetCardItemsByCardId(int cardId);
    }
}
