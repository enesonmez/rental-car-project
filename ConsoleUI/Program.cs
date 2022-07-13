using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BrandAddTest();
            //BrandUpdateTest();
            //BrandGetAllTest();
            //BrandGetByIdTest();

            //ColorAddTest();
            //ColorUpdateTest();
            //ColorDeleteTest();
            //ColorGetAllTest();
            //ColorGetById();

            //CarAddTest();
            //CarUpdateTest();
            //CarGetAllTest();
            //CarGetByIdTest();
            //CarGetCarsByBrandIdTest();
            //CarGetCarsByColorIdTest();
            //CarGetCarsDetailTest();

            //UserAddTest();
            //UserGetAllTest();

            //CustomerAddTest();
            //CustomerGetAllTest();

            //RentalAddTest();
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            Console.WriteLine(result.Success + " | " + result.Message);
        }

        private static void CustomerGetAllTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " | " + customer.UserId + " | " +
                    customer.CompanyName);
            }
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "BakAl"
            });
            Console.WriteLine(result.Success + " | " + result.Message);
        }

        private static void UserGetAllTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.UserId + " | " + user.FirstName + " | " +
                    user.LastName + " | " + user.Email + " | " + user.Password);
            }
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
            {
                FirstName = "Mehmet",
                LastName = "Sönmez",
                Email = "mehmet@gmail.com",
                Password = "123456789"
            });
            Console.WriteLine(result.Success + " | " + result.Message);
        }

        private static void CarGetCarsDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsDetail().Data)
            {
                Console.WriteLine(car.CarName + " | " + car.BrandName + " | " +
                    car.ColorName + " | " + car.DailyPrice);
            }
        }

        private static void CarGetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarId + " | " + car.BrandId + " | " + car.ColorId +
                    " | " + car.ModelYear + " | " + car.DailyPrice + " | " + car.CarName);
            }
        }

        private static void CarGetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine(car.CarId + " | " + car.BrandId + " | " + car.ColorId +
                    " | " + car.ModelYear + " | " + car.DailyPrice + " | " + car.CarName);
            }
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var car = carManager.GetById(3).Data;
            Console.WriteLine(car.CarId + " | " + car.BrandId + " | " + car.ColorId +
                    " | " + car.ModelYear + " | " + car.DailyPrice + " | " + car.CarName);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " | " + car.BrandId + " | " + car.ColorId +
                    " | " + car.ModelYear + " | " + car.DailyPrice + " | " + car.CarName);
            }
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                CarId = 8,
                BrandId = 9,
                ColorId = 1,
                ModelYear = 2021,
                DailyPrice = 379.90M,
                CarName = "octavia"
            });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 9,
                ColorId = 1,
                ModelYear = 2021,
                DailyPrice = 399.90M,
                CarName = "octavia"
            });
        }

        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color = colorManager.GetById(5).Data;
            Console.WriteLine(color.ColorId + " | " + color.ColorName);
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " | " + color.ColorName);
            }
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color
            {
                ColorId = 11
            });
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color
            {
                ColorId = 7,
                ColorName = "mavi"
            });
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color
            {
                ColorName = "fuşya"
            });
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetById(4).Data;
            Console.WriteLine(brand.BrandId + " | " + brand.BrandName);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " | " + brand.BrandName);
            }
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand
            {
                BrandId = 1,
                BrandName = "renault"
            });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandName = "toyota"
            });
        }
    }
}