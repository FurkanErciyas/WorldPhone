using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTOS.PhoneDTO
{
    public class PhonesDTO
    {
        public List<Brand> Brands { get; set; }
        public List<SmartPhone> Phones { get; set; }
        public int? BrandId { get; set; }
    }
}
