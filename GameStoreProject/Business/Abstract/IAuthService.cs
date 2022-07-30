using Core.Entities.Concrete;
using Core.Entities.Dto;
using Core.Utilities.Identities.Jwt;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> Login(UserLoginDto userLoginDto);
        IResult Register(User user);
    }
}
