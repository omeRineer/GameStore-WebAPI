using Core.Entities.Concrete;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleClaimService
    {
        IDataResult<List<RoleClaim>> GetAll();
        IDataResult<RoleClaim> GetById(int id);
        IResult Add(RoleClaim roleClaim);
        IResult Update(RoleClaim roleClaim);
        IResult Delete(int roleClaimId);
    }
}
