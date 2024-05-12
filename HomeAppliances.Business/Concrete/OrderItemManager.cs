using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Concrete.EfCore;
using HomeAppliances.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Concrete
{
	public class OrderItemManager : IOrderItemService
	{
		public void TCreate(OrderItem entity)
		{
			using (var context = new EfCoreContext())
			{
				context.Set<OrderItem>().Add(entity);
				context.SaveChanges();
			}
		}

		public void TDelete(OrderItem entity)
		{
			throw new NotImplementedException();
		}

		public List<OrderItem> TGetAll()
		{
			throw new NotImplementedException();
		}

		public OrderItem TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(OrderItem entity)
		{
			throw new NotImplementedException();
		}
	}
}
