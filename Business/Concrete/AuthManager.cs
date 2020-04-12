using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataTransferObjects;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IAdminService _adminService;
        private IRealEstateService _realEstateService;

        public AuthManager(IAdminService adminService, IRealEstateService realEstateService)
        {
            _adminService = adminService;
            _realEstateService = realEstateService;
        }

        public IDataResult<Admin> Register(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password , out passwordHash , out passwordSalt );

            var admin = new Admin
            {
                UserName = registerDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _adminService.Add(admin);
            return new SuccessDataResult<Admin>(admin,Messages.Registered);
        }

        public IDataResult<Admin> Login(LoginDto loginDto)
        {
            var adminToCheck = _adminService.GetByUsername(loginDto.UserName);
            if (adminToCheck == null)
            {
                return new ErrorDataResult<Admin>(Messages.AdminNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, adminToCheck.PasswordHash,
                adminToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Admin>(Messages.PasswordError);
            }

            return new SuccessDataResult<Admin>(adminToCheck , Messages.SuccessfulLogin);
        }

        public IResult AdminExists(string username)
        {
            if (_adminService.GetByUsername(username) != null)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<RealEstate> RegisterRealEstate(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password="123456", out passwordHash, out passwordSalt);

            var realEstate = new RealEstate
            {
                
                UserName = registerDto.UserName,
                CompanyName = registerDto.CompanyName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _realEstateService.Add(realEstate);
            return new SuccessDataResult<RealEstate>(realEstate, Messages.Registered);
        }

        public IDataResult<RealEstate> LoginRealEstate(LoginDto loginDto)
        {
            var realEstateToCheck = _realEstateService.GetByUsername(loginDto.UserName);
            if (realEstateToCheck == null)
            {
                return new ErrorDataResult<RealEstate>(Messages.AdminNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, realEstateToCheck.PasswordHash,
                realEstateToCheck.PasswordSalt))
            {
                return new ErrorDataResult<RealEstate>(Messages.PasswordError);
            }

            return new SuccessDataResult<RealEstate>(realEstateToCheck, Messages.SuccessfulLogin);
        }

      

        public IResult RealEstateExists(string username)
        {
            if (_realEstateService.GetByUsername(username) != null)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }
            return new SuccessResult();
        }

       
    }
}
