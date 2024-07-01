using AutoMapper;
using BLL.Interfaces;
using ENTITIES.DTOS.BrandDTO;
using ENTITIES.Models;
using WorldPhone.DAL.Context;

namespace BLL.Services
{
    public class BrandService : IBrand
    {
        private readonly WorldPhoneDbContext _db;
        private readonly IMapper _mapper;

        public BrandService(WorldPhoneDbContext db, IMapper mapper)
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

        public List<Brand> GetAllBrands()
        {
            return _db.Brands.ToList();
        }
    }
}
