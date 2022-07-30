using Core.Entities.Concrete;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRoleClaimService
    {
        IDataResult<List<UserRoleClaim>> GetAll();
        IDataResult<List<UserRoleClaim>> GetAllByUserId(int userId);
        IDataResult<UserRoleClaim> GetById(int id);
        IResult Add(UserRoleClaim userRoleClaim);
        IResult Update(UserRoleClaim userRoleClaim);
        IResult Delete(int userRoleClaimId);
    }
}
