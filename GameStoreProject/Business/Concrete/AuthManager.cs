using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dto;
using Core.Utilities.Identities.Jwt;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IUserRoleClaimService _userRoleClaimService;
        public AuthManager(IUserService userService, 
                           ITokenService tokenService,
                           IUserRoleClaimService userRoleClaimService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userRoleClaimService = userRoleClaimService;
        }

        public IDataResult<AccessToken> Login(UserLoginDto userLoginDto)
        {
            var user=_userService.GetByLoginModel(userLoginDto.UserName, userLoginDto.Password).Data;
            if (user!=null)
            {
                return new ErrorDataResult<AccessToken>();
            }

            var userRoleClaims = _userService.GetUserRoleClaims(user.Id);
            var accessToken = _tokenService.GenerateToken(user,userRoleClaims.Data);

            return new SuccessDataResult<AccessToken>(accessToken);

        }

        public IResult Register(User user)
        {
            throw new NotImplementedException();
        }


    }
}
