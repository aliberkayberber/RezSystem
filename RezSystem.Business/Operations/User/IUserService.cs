using RezSystem.Business.Operations.User.Dtos;
using RezSystem.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezSystem.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user);
    }
}
