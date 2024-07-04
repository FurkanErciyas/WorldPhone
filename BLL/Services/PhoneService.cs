using AutoMapper;
using BLL.Interfaces;
using ENTITIES.DTOS.BrandDTO;
using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Enums;
using ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WorldPhone.DAL.Context;

namespace BLL.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly WorldPhoneDbContext _db;
        private readonly IMapper _mapper;

        public PhoneService(WorldPhoneDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddBrand(AddBrandDTO brand)
        {
            try
            {
                var newBrand = _mapper.Map<Brand>(brand);
                _db.Brands.Add(newBrand);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
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

        public List<Brand> GetAllBrands()
        {
            return _db.Brands.ToList();
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

        public PhonesDTO GetPhonesByBrand(string brandName)
        {
            var brand = _db.Brands.Include(b => b.SmartPhones).FirstOrDefault(b => b.BrandName == brandName);

            var phonesDTO = new PhonesDTO();

            phonesDTO.Phones = brand.SmartPhones;
            phonesDTO.Brands = _db.Brands.ToList();
            phonesDTO.BrandId = brand.Id;

            return phonesDTO;
        }

        public PhonesDTO GetPhonesDTO()
        {
            var phonesDTO = new PhonesDTO()
            {
                Phones = _db.SmartPhones.Include(x => x.Brand).ToList(),
                Brands = _db.Brands.OrderBy(x => x.BrandName).ToList()
            };

            return phonesDTO;
        }
    }
}
