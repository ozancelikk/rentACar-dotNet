using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class CarManager : ICarService {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public void Add(Car car) {
            if(car.Description.Length <= 10) {
                Console.WriteLine("Açıklama 10 karakter daha az olamaz");
            }else if(car.DailyPrice <=0){
                Console.WriteLine("Arabanın günlük fiyatı 0TL'den büyük olması gereklidir.");
            } else {
                _carDal.Add(car);
            }
            
        }
        public void Delete(Car car) {
            _carDal.Delete(car);
        }

        public void Update(Car car) {
            _carDal.Update(car);
        }

        public List<Car> GetAll() {
            return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int id) {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id) {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails() {
            return _carDal.GetCarDetails();
        }
    }
}
