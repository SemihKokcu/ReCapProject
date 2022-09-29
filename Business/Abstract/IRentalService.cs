using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Uptade(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> Get(int id);
        IDataResult<List<Rental>> AllRentalCars();
        IDataResult<List<Rental>> RentedCars();
        IDataResult<List<Rental>> NotRentedCars();
        IDataResult<List<RentalDetailDto>> GetRentalCarDetails();
    }
}
