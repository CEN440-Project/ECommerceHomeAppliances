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
	public class EfCoreCardDal : EfCoreGenericRepository<Card, EfCoreContext>, ICardDal
	{

		
		public override void Update(Card entity)
		{
			using (var context = new EfCoreContext())
			{
				context.Cards.Update(entity);
				context.SaveChanges();
			}
		}

		public Card GetByUserID(string userId)
		{
			using (var context = new EfCoreContext())
			{
				return context
							.Cards
							.Include(i => i.CardItems)
							.ThenInclude(i => i.Product)
							.FirstOrDefault(i => i.UserID == userId);
			}
		}
		public void DeleteFromCard(int cardId, int productId)
		{
			using (var context = new EfCoreContext())
			{
				context.Database.ExecuteSql($"delete from CardItem where CardId={cardId} And ProductId={productId}");
			}
		}

		public void ClearCard(int cardId)
		{
			using (var context = new EfCoreContext())
			{
				var entity = context.CardItems.Where(i => i.CardId == cardId).ToList();
				//context.Database.ExecuteSql($"delete from CardItems where CardId={cardId}");
				context.Set<CardItem>().RemoveRange(entity);
				context.SaveChanges();
			}
		}

		public void ClearCard(string cardId)
		{
			throw new NotImplementedException();
		}
	}
}
