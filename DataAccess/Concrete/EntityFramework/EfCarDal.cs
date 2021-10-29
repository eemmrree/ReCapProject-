using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using var context = new ReCapProjectContext();
            var result = from p in context.Cars
                join col in context.Colors on p.ColorId equals col.Id
                join b in context.Brands on p.BrandId equals b.Id
                select new CarDetailDto { Id = p.Id, BrandName = b.Name, ColorName = col.Name, DailyPrice = p.DailyPrice };

            return result.ToList();
        }
    }
}
