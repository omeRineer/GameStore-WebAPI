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
    public class RoleClaimManager : IRoleClaimService
    {
        private readonly IRoleClaimDal _roleClaimDal;
        public RoleClaimManager(IRoleClaimDal roleClaimDal)
        {
            _roleClaimDal = roleClaimDal;
        }

        [ValidationAspect(typeof(RoleClaimValidator))]
        public IResult Add(RoleClaim roleClaim)
        {
            _roleClaimDal.Add(roleClaim);
            return new SuccessResult();
        }

        public IResult Delete(int roleClaimId)
        {
            var entity=_roleClaimDal.Get(x=>x.Id==roleClaimId);
            _roleClaimDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<RoleClaim>> GetAll()
        {
            var result = _roleClaimDal.GetAll();
            return new SuccessDataResult<List<RoleClaim>>(result);
        }

        public IDataResult<RoleClaim> GetById(int id)
        {
            var result=_roleClaimDal.Get(x=>x.Id == id);
            return new SuccessDataResult<RoleClaim>(result);
        }

        [ValidationAspect(typeof(RoleClaimValidator))]
        public IResult Update(RoleClaim roleClaim)
        {
            _roleClaimDal.Update(roleClaim);
            return new SuccessResult();
        }
    }
}
