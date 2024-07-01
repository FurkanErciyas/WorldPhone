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
        void AddPhone(AddPhoneDTO phone);
        List<SmartPhone> GetAllPhones();
    }
}
