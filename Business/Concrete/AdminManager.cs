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
    public class AdminManager:IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<Admin> GetById(int adminId)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(a => a.Id == adminId)); 
        }

        public IResult Add(Admin admin)
        {
            _adminDal.Add(admin);
            return new SuccessResult(Messages.AdminAdded);
        }

        public IResult Delete(Admin admin)
        {
           _adminDal.Delete(admin);
           return new SuccessResult(Messages.AdminDeleted);
        }

        public Admin GetByUsername(string username)
        {
            return _adminDal.Get(a => a.UserName == username);
        }

      
        public List<Admin> GetList()
        {
            return _adminDal.GetList().ToList();
        }

        public IResult Update(Admin admin)
        {
            _adminDal.Update(admin);
            return new SuccessResult(Messages.AdminUpdated);
        }
    }
}
