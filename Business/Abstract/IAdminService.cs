using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdminService
    {
        IResult Add(Admin admin);

        Admin GetByUsername(string username);

    }
}
