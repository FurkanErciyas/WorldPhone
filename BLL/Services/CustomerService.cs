using BLL.Interfaces;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPhone.DAL.Context;

namespace BLL.Services
{
    public class CustomerService : ICustomer
    {
        private readonly WorldPhoneDbContext _db;

        public CustomerService(WorldPhoneDbContext db)
        {
            _db = db;
        }

        public List<Brand> GetBrands()
        {
            var brands = _db.Brands.ToList();
            return brands;
        }
    }
}
