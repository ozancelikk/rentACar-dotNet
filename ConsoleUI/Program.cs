using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI {
    public class Program {
        public static void Main(string[] args) {
            //CarTest();
            //ColorTest();
            //CarDetailtTest();
            CustomerTest();
        }

        private static void CarTest() {
            CarManager carManager = new CarManager(new EfCarDal());

            Car newCar = new Car() { Id = 11, BrandId = 2, ColorId = 2, DailyPrice = 600, ModelYear = "2002", Description = "perfect machine" };
            carManager.Add(newCar);
            
            foreach (var car in carManager.GetAll().Data) {
                Console.WriteLine(car.Id);
            }
        }
        private static void ColorTest() {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            
            foreach(var color in colorManager.GetAll().Data) {
                Console.WriteLine(color.Name + " - " + color.Id);
            }
            colorManager.Delete(new Color() { Id = 10, Name = "Pembe" });
            foreach (var color in colorManager.GetAll().Data) {
                Console.WriteLine(color.Name + " - " + color.Id);
            }
        }
        private static void CarDetailtTest() {
            CarManager carmanager = new CarManager(new EfCarDal());
            foreach (var carDetail in carmanager.GetCarDetails().Data) {
                Console.WriteLine(carDetail.CarName + " - " + carDetail.ColorName + " - " + carDetail.BrandName + " - " + carDetail.DailyPrice );
            }
            
        }
        private static void CustomerTest() {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() { UserId = 1, CompanyName = "Abc Company" });
            customerManager.Add(new Customer() { UserId = 3, CompanyName = "Wzq Company" });
            customerManager.Add(new Customer() { UserId = 6, CompanyName = "Plv Company" });

            foreach(var customer in customerManager.GetAll().Data) {
                Console.WriteLine(customer.UserId);
            }
        }

        
    }
}
