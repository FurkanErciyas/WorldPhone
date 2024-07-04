using ENTITIES.DTOS.BrandDTO;
using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhoneService
    {
        void AddPhone(AddPhoneDTO phone, string fileName);
        List<SmartPhone> GetAllPhones();
        void DeletePhone(int id);
        SmartPhone GetPhone(int id);
        void EditPhone(EditPhoneDTO phone);
        EditPhoneDTO EditPhoneDTO(int id);
        PhonesDTO GetPhonesByBrand(string BrandName);
        PhonesDTO GetPhonesDTO();
        List<Brand> GetAllBrands();
        void AddBrand(AddBrandDTO brand);
    }
}
