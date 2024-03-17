using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface ICardService
    {
        void InitializeCart(string userId);
        Card GetByUserID(string userId);
        void AddToCart(string userId, int productId, int quantity);
        void DeleteFromCard(int cardId, int productId);
        void ClearCard(string cardId);
    }
}
