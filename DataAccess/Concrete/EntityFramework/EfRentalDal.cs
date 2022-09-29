using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarID equals car.Id
                             join customer in context.Customers
                             on rental.CustomerID equals customer.CustomerID
                             join user in context.Users
                             on customer.UserID equals user.UserID
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new RentalDetailDto
                             {
                                 CarId = rental.CarID,
                                 CarModel = car.ModelYear,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 CustomerCompanyName = customer.CompanyName,
                                 CustomerFirstName =  customer.FirstName,
                                 CustomerLastName = customer.LastName,
                                 CarRentDate = rental.RentDate,
                                 CarReturnTime = rental.ReturnDate
                                 

                             };
                return result.ToList();
            }
        }
    }
}
