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
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, Context>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new Context())
            {
                var orders = context.Orders
                                .Include(i => i.OrderItems)
                                .ThenInclude(i => i.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserID == userId);
                }

                return orders.ToList();
            }
        }
    }
}
