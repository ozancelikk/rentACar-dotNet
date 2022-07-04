using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails() {
            using(CarRentalContext context = new CarRentalContext()) {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarName = b.Name,
                                 ColorName = cl.Name,
                                 BrandName = b.Name,
                                 DailyPrice = cr.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
