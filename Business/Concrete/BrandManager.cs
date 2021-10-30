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
    public class BrandManager:IBrandService
    {
        readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brand)
        {
            _brandDal = brand;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name != null)
            {
                _brandDal.Add(brand);
                return new SuccessResult("Added");
            }
            else
            {
                return new ErrorResult("Warning");
            }
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Deleted");
        }

        public IResult Update(Brand brand)
        {
            if (brand.Name != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult("Updated");
            }
            else
            {
                return new ErrorResult("Warning");
            }
        }
    }
}
