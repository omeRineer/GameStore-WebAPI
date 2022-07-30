using Core.Entities.Concrete;
using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByLoginModel(string userName, string password);
        IDataResult<List<RoleClaim>> GetUserRoleClaims(int userId);
        IResult Add(User user);
        IResult Delete(int userId);
        IResult Update(User user);

    }
}
