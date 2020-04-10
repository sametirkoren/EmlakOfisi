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
    public class HeatingManager : IHeatingService
    {
        private IHeatingDal _heatingDal;

        public HeatingManager(IHeatingDal heatingDal)
        {
            _heatingDal = heatingDal;
        }

        public IResult Add(Heating heating)
        {
            _heatingDal.Add(heating);
            return new SuccessResult(Messages.HeatingAdded);
        }

        public IResult Delete(Heating heating)
        {
            _heatingDal.Delete(heating);
            return new SuccessResult(Messages.HeatingDeleted);
        }

        public IResult Update(Heating heating)
        {
            _heatingDal.Update(heating);
            return new SuccessResult(Messages.HeatingUpdated);
        }

        public List<Heating> GetList()
        {
            return _heatingDal.GetList().ToList();
        }
    }
}
