using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhone
    {
        void AddPhone(AddPhoneDTO phone, string fileName);
        List<SmartPhone> GetAllPhones();
        void DeletePhone(int id);
        SmartPhone GetPhone(int id);
        void EditPhone(EditPhoneDTO phone);
        EditPhoneDTO EditPhoneDTO(int id);
    }
}
