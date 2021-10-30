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

            BrandTest();

            ColorTest();
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

        private static void BrandTest()
        {
            var brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("----------Brands------------");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + " - " +brand.Name);
            }
            
        }

        private static void ColorTest()
        {
            var colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("----------Colors------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " - " + color.Name);
            }
        }
    }
}
