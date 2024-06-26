using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class Brand : BaseEntity
    {
        [Required, MaxLength(20)]
        public string? BrandName { get; set; }
        public List<SmartPhone>? SmartPhones { get; set; }
    }
}
