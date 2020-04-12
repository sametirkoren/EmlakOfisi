using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<Admin> GetById(int adminId);
        IResult Add(Admin admin);

        Admin GetByUsername(string username);

        IResult Delete(Admin admin);

        IResult Update(Admin admin);


        List<Admin> GetList();

    }
}
