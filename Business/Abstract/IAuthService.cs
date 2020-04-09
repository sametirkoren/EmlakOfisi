using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using DataTransferObjects;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Admin> Register(RegisterDto registerDto);
        IDataResult<Admin> Login(LoginDto loginDto);

        IDataResult<RealEstate> RegisterRealEstate(RegisterDto registerDto);
        IDataResult<RealEstate> LoginRealEstate(LoginDto loginDto);

        IResult AdminExists(string username);
        IResult RealEstateExists(string username);
    }
}
