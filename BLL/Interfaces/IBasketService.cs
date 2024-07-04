using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync(string buyerId);
        Task<Basket> AddItemToBasketAsync(string buyerId, int phoneId, int quantity);
        Task<int> GetBasketItemCountAsync(string buyerId);
        Task TransferBasketAsync(string sourceBuyerId, string targetBuyerId);
        Task DeleteBasketAsync(string buyerId);
        Task DeleteBasketItemAsync(string buyerId, int basketItemId);
        Task<Basket> SetQuantities(string buyerId, Dictionary<int, int> quantities);
    }
}
