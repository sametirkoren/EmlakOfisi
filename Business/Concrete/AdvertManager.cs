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
    public class AdvertManager : IAdvertService
    {
        private IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public IDataResult<Advert> GetById(int advertId)
        {
            return new SuccessDataResult<Advert>(_advertDal.Get(a => a.Id == advertId)); 
        }

        public IDataResult<List<Advert>> GetAll()
        {
            return new SuccessDataResult<List<Advert>>(_advertDal.GetList().ToList());
        }

        public IDataResult<List<Advert>> GetByRealEstate(int realEstateId)
        {
            return new SuccessDataResult<List<Advert>>(_advertDal.GetList(a => a.RealEstateId == realEstateId).ToList());
        }

        public IResult Add(Advert advert)
        {
            _advertDal.Add(advert);
            return new SuccessResult(Messages.AdvertAdded);
        }

        public IResult Delete(Advert advert)
        {
            _advertDal.Delete(advert);
            return new SuccessResult(Messages.AdvertDeleted);
        }

        public IResult Update(Advert advert)
        {
            _advertDal.Update(advert);
            return new SuccessResult(Messages.AdvertUpdated);
        }
    }
}
