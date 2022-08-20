using Business.Abstract;
using Core.Aspects.Authorizaton;
using Core.Entities.Concrete;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleClaimManager : IUserRoleClaimService
    {
        private readonly IUserRoleClaimDal _userRoleClaimDal;
        public UserRoleClaimManager(IUserRoleClaimDal userRoleClaimDal)
        {
            _userRoleClaimDal = userRoleClaimDal;
        }

        public IResult Add(UserRoleClaim userRoleClaim)
        {
            _userRoleClaimDal.Add(userRoleClaim);
            return new SuccessResult();
        }

        public IResult Delete(int userRoleClaimId)
        {
            var entity=_userRoleClaimDal.Get(x=>x.Id == userRoleClaimId);
            _userRoleClaimDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<UserRoleClaim>> GetAll()
        {
            var result=_userRoleClaimDal.GetAll();
            return new SuccessDataResult<List<UserRoleClaim>>(result);
        }

        public IDataResult<List<UserRoleClaim>> GetAllByUserId(int userId)
        {
            var result=_userRoleClaimDal.GetAll(x=>x.UserId == userId);
            return new SuccessDataResult<List<UserRoleClaim>>(result);
        }

        public IDataResult<UserRoleClaim> GetById(int id)
        {
            var result = _userRoleClaimDal.Get(x => x.Id == id);
            return new SuccessDataResult<UserRoleClaim>(result);
        }

        public IResult Update(UserRoleClaim userRoleClaim)
        {
            _userRoleClaimDal.Update(userRoleClaim);
            return new SuccessResult();
        }
    }
}
