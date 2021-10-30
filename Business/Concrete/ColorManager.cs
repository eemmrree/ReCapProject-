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
    public class ColorManager:IColorService
    {
        readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Add(Color color)
        {
            if (color.Name!=null)
            {
                _colorDal.Add(color);
                return new SuccessResult("Added");
            }
            else
            {
                return new ErrorResult("Warning");
            }
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Deleted");
            
          
        }

        public IResult Update(Color color)
        {
            if (color.Name != null)
            {
                _colorDal.Update(color);
                return new SuccessResult("Updated");
            }
            else
            {
                return new ErrorResult("Warning");
            }
        }
    }
}
