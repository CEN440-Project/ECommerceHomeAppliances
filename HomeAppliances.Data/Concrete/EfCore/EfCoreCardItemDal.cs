using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Data.Concrete.EfCore
{
    public class EfCoreCardItemDal : EfCoreGenericRepository<CardItem, EfCoreContext>, ICardItemDal
    {
        //
        public List<CardItem> GetCardItemsByCardId(int cardId)
        {
            using (var context = new EfCoreContext())
            {
                return context.CardItems
                            .Where(x => x.CardId == cardId)
                            .ToList();
            }
        }

        public List<CardItem> GetCardItemsWithProducts()
        {
            using (var context = new EfCoreContext())
            {
                return context.CardItems
                            .Include(x => x.Product)
                            .ToList();
            }
        }
    }
}
