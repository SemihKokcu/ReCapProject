using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetProductDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                           join b in context.Brands
                           on c.BrandId equals b.Id
                           join c2 in context.Colors
                           on c.ColorId equals c2.Id
                           select new CarDetailDto
                           {
                               CarName = c.Name,
                               BrandName = b.Name,
                               ColorName = c2.Name,
                               DailyPrice = c.DailyPrice
                           };
                return result.ToList();

            }
        }
    }
}

