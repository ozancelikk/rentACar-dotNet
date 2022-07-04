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
            CarDetailtTest();
        }

        private static void CarTest() {
            CarManager carManager = new CarManager(new EfCarDal());

            Car newCar = new Car() { Id = 10, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = "2001", Description = "yeni model araba cok iyi" };
            carManager.Add(newCar);

            foreach (var car in carManager.GetAll()) {
                Console.WriteLine(car.Id);
            }
        }
        private static void ColorTest() {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            
            foreach(var color in colorManager.GetAll()) {
                Console.WriteLine(color.Name + " - " + color.Id);
            }
            colorManager.Delete(new Color() { Id = 10, Name = "Pembe" });
            foreach (var color in colorManager.GetAll()) {
                Console.WriteLine(color.Name + " - " + color.Id);
            }
        }
        private static void CarDetailtTest() {
            CarManager carmanager = new CarManager(new EfCarDal());
            foreach (var carDetail in carmanager.GetCarDetails()) {
                Console.WriteLine(carDetail.CarName + " - " + carDetail.ColorName + " - " + carDetail.BrandName + " - " + carDetail.DailyPrice );
            }
            
        }
    }
}
