using RezSystem.Business.DataProtection;
using RezSystem.Business.Operations.User.Dtos;
using RezSystem.Business.Types;
using RezSystem.Data.Entities;
using RezSystem.Data.Enums;
using RezSystem.Data.Repositories;
using RezSystem.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezSystem.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtection _dataProtector;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository,IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtector = dataProtection;
        }


        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if(hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Bu mail adresi zaten kayıtlı."
                };
            }

            var userEntity = new UserEntity
            {
                Email = user.Email,
                Password = _dataProtector.Protect(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = UserType.Customer
                
            };

            _userRepository.Add(userEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw new Exception("Kullanıcı kaydı sırasında bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Kullanıcı başarıyla eklendi."
            };

        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user)
        {
            var userEntity = _userRepository.Get(x=> x.Email.ToLower() == user.Email.ToLower());

            if(userEntity == null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                };
            }

            var unprotectedPassword = _dataProtector.UnProtect(userEntity.Password);

            if(unprotectedPassword == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = true,
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        UserType = userEntity.UserType
                    },
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSuccess = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                };
            }

        }
    }
}
