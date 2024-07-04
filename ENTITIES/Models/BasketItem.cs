using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class BasketItem : BaseEntity
    {
        public int PhoneId { get; set; }
        public int Quantity { get; set; }
        public int BasketId { get; set; }
        public SmartPhone Phone { get; set; }
    }
}
