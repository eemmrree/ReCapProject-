using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            CarTest();
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.DailyPrice + " - " + car.Description + " - " + car.ModelYear);
            }

            Console.WriteLine("---------------CarDetail-----------------");

            foreach (var carDetail in carManager.GetCarDetail().Data)
            {
                Console.WriteLine(carDetail.Id +" - " +carDetail.BrandName+" - " +carDetail.ColorName+" -> " +carDetail.DailyPrice);
            }

        }
    }
}
