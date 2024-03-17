using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public void AddToCard(string userId, int productId, int quantity)
        {
            var card = GetCardByUserID(userId);
            if (card != null)
            {
                var index = card.CardItems.FindIndex(i => i.ProductId == productId);

                if (index < 0)
                {
                    card.CardItems.Add(new CardItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CardId = card.Id
                    });
                }
                else
                {
                    card.CardItems[index].Quantity += quantity;
                }

                _cardDal.Update(card);
            }
        }

        public void ClearCard(string cardId)
        {
            _cardDal.ClearCard(cardId);
        }

        public void DeleteFromCard(string userId, int productId)
        {
            var card = GetCardByUserID(userId);
            if (card != null)
            {
                _cardDal.DeleteFromCard(card.Id, productId);
            }
        }

        public Card GetCardByUserID(string userId)
        {
            return _cardDal.GetByUserID(userId);
        }

        public void InitializeCard(string userId)
        {
            _cardDal.Create(new Card() { UserID = userId });
        }
    }
}
