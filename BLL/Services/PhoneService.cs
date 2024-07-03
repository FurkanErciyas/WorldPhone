using AutoMapper;
using BLL.Interfaces;
using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Enums;
using ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using WorldPhone.DAL.Context;

namespace BLL.Services
{
    public class PhoneService : IPhone
    {
        private readonly WorldPhoneDbContext _db;
        private readonly IMapper _mapper;

        public PhoneService(WorldPhoneDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void AddPhone(AddPhoneDTO phone, string fileName)
        {
            try
            {
                var newPhone = _mapper.Map<SmartPhone>(phone);
                newPhone.PicturePath = fileName;
                _db.SmartPhones.Add(newPhone);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePhone(int id)
        {
            try
            {
                var phone = GetPhone(id);
                if (phone != null)
                {

                    phone.Status = StatusEnum.Passive;
                    phone.DataStatus = DataStatusEnum.Deleted;
                    phone.DeletedDate = DateTime.Now;
                    _db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void EditPhone(EditPhoneDTO phoneDTO)
        {
            try
            {
                var phone = GetPhone(phoneDTO.Id);

                if(phone != null)
                {
                    _mapper.Map(phoneDTO, phone);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EditPhoneDTO EditPhoneDTO(int id)
        {
            var phone = GetPhone(id);
            return _mapper.Map<EditPhoneDTO>(phone);
        }

        public List<SmartPhone> GetAllPhones()
        {
            var phones = _db.SmartPhones.ToList();
            return phones;
        }

        public SmartPhone GetPhone(int id)
        {
            return _db.SmartPhones.Find(id);
        }
    }
}
