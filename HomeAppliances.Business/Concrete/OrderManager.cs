using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Create(Order entity)
        {
            _orderDal.Create(entity);
        }

		public Order GetOrderByUserId(int userId)
		{
			using (var context = new EfCoreContext())
			{
				return context.Set<Order>().Where(x=>x.UserID == userId.ToString()).OrderByDescending(x => x.OrderID).FirstOrDefault();
			}
		}

		public List<Order> GetOrders(string userId)
        {
            return _orderDal.GetOrders(userId);
        }

		public void TCreate(Order entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public List<Order> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Order TGetById(int id)
		{
			using (var context = new EfCoreContext())
			{
				return context.Set<Order>().Find(id);
			}
		}

		public void TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
