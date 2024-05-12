﻿using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
        Order GetOrderByUserId(int userId);
    }
}
