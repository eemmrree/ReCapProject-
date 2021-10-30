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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using var context = new ReCapProjectContext();
            var result = from user in context.Users
                join customer in context.Customers
                    on user.Id equals customer.UserId
                join rental in context.Rentals
                    on customer.Id equals rental.CustomerId
                join car in context.Cars
                    on rental.CarId equals car.Id
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                select new RentalDetailDto
                {
                    Id = rental.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BrandName = brand.Name,
                    ModelYear = car.ModelYear,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice,
                    RentDate = rental.RentDate,
                    ReturnDate = rental.ReturnDate
                };
            return result.ToList();
        }
    }
}
