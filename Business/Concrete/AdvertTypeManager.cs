using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AdvertTypeManager : IAdvertTypeService
    {
        private IAdvertTypeDal _advertTypeDal;

        public AdvertTypeManager(IAdvertTypeDal advertTypeDal)
        {
            _advertTypeDal = advertTypeDal;
        }

        public IResult Add(AdvertType advertType)
        {
            _advertTypeDal.Add(advertType);
            return new SuccessResult(Messages.AdvertTypeAdded);
        }

        public IResult Delete(AdvertType advertType)
        {
            _advertTypeDal.Delete(advertType);
            return new SuccessResult(Messages.AdvertTypeDeleted);
        }

        public List<AdvertType> GetList()
        {
            return _advertTypeDal.GetList().ToList();
        }

        public IResult Update(AdvertType advertType)
        {
            _advertTypeDal.Update(advertType);
            return new SuccessResult(Messages.AdvertTypeUpdated);
        }

        public IDataResult<AdvertType> GetById(int advertTypeId)
        {

            return new SuccessDataResult<AdvertType>(_advertTypeDal.Get(a => a.Id == advertTypeId));
        }
    }
}
