using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryProductDal : IProductDal {

        List<Car> _cars;
        public InMemoryProductDal() {
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandID = 1, ColorID = 1, DailyPrice = 400, Description = "power", ModelYear="2020" },
                new Car{ Id = 2, BrandID = 2, ColorID = 2, DailyPrice = 500, Description = "economic", ModelYear="2021" },
                new Car{ Id = 3, BrandID = 2, ColorID = 3, DailyPrice = 200, Description = "power", ModelYear="2018" },
                new Car{ Id = 4, BrandID = 4, ColorID = 5, DailyPrice = 300, Description = "big", ModelYear="2019" },
                new Car{ Id = 5, BrandID = 3, ColorID = 5, DailyPrice = 100, Description = "small", ModelYear="2015" },
            };
        }
        public void Add(Car car) {
            _cars.Add(car);
        }

        public void Delete(Car car) {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll() {
            return _cars;
        }

        public Car GetById(int id) {
            return (Car)_cars.Where(c => c.Id == id);
        }

        public void Update(Car car) {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorID = car.ColorID;

        }
    }
}
