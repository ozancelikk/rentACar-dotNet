using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car) {
            if(car.Description.Length <= 10) {
                //Console.WriteLine("Açıklama 10 karakter daha az olamaz");
                //return new Result(false, "Açıklama 10 karakter daha az olamaz");
                return new ErrorResult("Açıklama 10 karakter daha az olamaz");
            } else if(car.DailyPrice <=0){
                //Console.WriteLine("Arabanın günlük fiyatı 0TL'den büyük olması gereklidir.");
                return new ErrorResult("Arabanın günlük fiyatı 0TL'den büyük olması gereklidir.");
            } else {
                _carDal.Add(car);
            }
            //return new Result(true,"Ekleme yapıldı")
            return new SuccessResult("Araba eklendi");
            
        }
        public IResult Delete(Car car) {
            _carDal.Delete(car);
            return new SuccessResult("Araba silindi");
        }

        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult("Araba güncellendi");
        }

        public IDataResult<List<Car>> GetAll() {
            //return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails() {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int carId) {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), "Aradığınız araç bulundu");
        }
    }
}
