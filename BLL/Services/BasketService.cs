using BLL.Interfaces;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BasketService : IBasketService
    {
        public Task<Basket> AddItemToBasketAsync(string buyerId, int phoneId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBasketAsync(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBasketItemAsync(string buyerId, int basketItemId)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketAsync(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetBasketItemCountAsync(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> SetQuantities(string buyerId, Dictionary<int, int> quantities)
        {
            throw new NotImplementedException();
        }

        public Task TransferBasketAsync(string sourceBuyerId, string targetBuyerId)
        {
            throw new NotImplementedException();
        }
    }
}
