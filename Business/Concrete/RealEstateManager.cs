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
    public class RealEstateManager : IRealEstateService
    {
        private IRealEstateDal _realEstateDal;

        public RealEstateManager(IRealEstateDal realEstateDal)
        {
            _realEstateDal = realEstateDal;
        }

       
        public List<RealEstate> GetList()
        {
            return _realEstateDal.GetList().ToList();
        }

        public IResult Add(RealEstate realEstate)
        {
            _realEstateDal.Add(realEstate);
            return new SuccessResult(Messages.RealEstateAdded);
        }

        public IResult Delete(RealEstate realEstate)
        {
            _realEstateDal.Delete(realEstate);
            return new SuccessResult(Messages.RealEstateDeleted);
        }

        /*public IDataResult<List<RealEstate>> GetByAdvert(int advertId)
        {
            throw new NotImplementedException();
        }*/

        public IDataResult<RealEstate> GetById(int realEstateId)
        {

            return new SuccessDataResult<RealEstate>(_realEstateDal.Get(a => a.Id == realEstateId));
        }

        public RealEstate GetByUsername(string username)
        {
            return _realEstateDal.Get(a => a.UserName == username);
        }

        public IResult Update(RealEstate realEstate)
        {
            _realEstateDal.Update(realEstate);
            return new SuccessResult(Messages.RealEstateUpdated);
        }
    }
}
