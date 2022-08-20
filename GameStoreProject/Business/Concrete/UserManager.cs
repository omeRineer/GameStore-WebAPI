using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Authorizaton;
using Core.Aspects.Validation;
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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(int userId)
        {
            var entity=_userDal.Get(x=>x.Id == userId);
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetById(int id)
        {
            var result=_userDal.Get(x=>x.Id==id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByLoginModel(string userName, string password)
        {
            var result = _userDal.Get(x=>x.UserName==userName && x.Password==password);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<RoleClaim>> GetUserRoleClaims(int userId)
        {
            var result=_userDal.GetUserRoleClaims(userId);
            return new SuccessDataResult<List<RoleClaim>>(result);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
