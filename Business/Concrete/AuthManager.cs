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

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
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

        public IResult Exists(string username)
        {
            if (_adminService.GetByUsername(username) != null)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
