using AutoMapper;
using BLL.Interfaces;
using ENTITIES.DTOS.PhoneDTO;
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
        public void AddPhone(AddPhoneDTO phone)
        {
            try
            {
                string picturePath = HandleImageUpload(phone.Image);
                var newPhone = _mapper.Map<SmartPhone>(phone);
                newPhone.PicturePath = picturePath;
                _db.SmartPhones.Add(newPhone);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SmartPhone> GetAllPhones()
        {
            var phones = _db.SmartPhones.ToList();
            return phones;
        }

        private string HandleImageUpload(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                return "/uploads/" + imageFile.FileName;
            }
            return "/uploads/default.jpg";
        }
    }
}
