using ENTITIES.DTOS.BrandDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBrand
    {
        List<Brand> GetAllBrands();
        void AddBrand(AddBrandDTO brand);
    }
}
