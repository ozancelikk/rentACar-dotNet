using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryCarDal : ICarDal {

        List<Car> _cars;
        public InMemoryCarDal() {
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 400, Description = "power", ModelYear="2020" },
                new Car{ Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 500, Description = "economic", ModelYear="2021" },
                new Car{ Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 200, Description = "power", ModelYear="2018" },
                new Car{ Id = 4, BrandId = 4, ColorId = 5, DailyPrice = 300, Description = "big", ModelYear="2019" },
                new Car{ Id = 5, BrandId = 3, ColorId = 5, DailyPrice = 100, Description = "small", ModelYear="2015" },
            };
        }
        public void Add(Car car) {
            _cars.Add(car);
        }

        public void Delete(Car car) {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get() {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter) {
            throw new NotImplementedException();
        }

        public List<Car> GetAll() {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null) {
            throw new NotImplementedException();
        }

        public Car GetById(int id) {
            return (Car)_cars.Where(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails() {
            throw new NotImplementedException();
        }

        public void Update(Car car) {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}
