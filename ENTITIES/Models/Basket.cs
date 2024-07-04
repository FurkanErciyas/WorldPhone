using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            
        }

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }

        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
