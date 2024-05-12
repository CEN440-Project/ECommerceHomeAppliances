using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface ICardItemService : IGenericService<CardItem>
    {
        List<CardItem> GetCardItemsWithProducts();
        List<CardItem> GetCardItemsByCardId(int cardId);
    }
}
