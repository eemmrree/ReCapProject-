using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true);
        }

        public IResult Add(Rental rental)
        {
            var rentalDate = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (rentalDate == null || rentalDate.ReturnDate < DateTime.Now.Date)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Added");
            }
            else
            {
                return new ErrorResult("Warning");
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Deleted");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Updated");
        }
    }
}
