using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal; 
        }
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(
                IsCarAlreadyRented(rental.CarId)
                );

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> AllRentalCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id),Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(),Messages.RentalListedByCarDetails);
        }

        public IDataResult<List<Rental>> GetNotRentedCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.ReturnDate==null),Messages.RentalListedByNotRentedCars);
        }

        public IDataResult<List<Rental>> GetRentedCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null),Messages.RentalListedByRentedCars);

        }

        public IResult Uptade(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult IsCarAlreadyRented(int cadId)
        {
            var result = _rentalDal.Get(p => p.CarId == cadId && p.ReturnDate == null);
            if (result == null)
            {
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.CarIsAlreadyRented);
        }
    }
}
