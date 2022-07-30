using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, Context>, IUserDal
    {
        public List<RoleClaim> GetUserRoleClaims(int userId)
        {
            using (var context=new Context())
            {
                var result=(from x in context.Users where x.Id == userId
                            join y in context.UserRoleClaims
                            on x.Id equals y.UserId
                            join z in context.RoleClaims
                            on y.RoleClaimId equals z.Id
                            select 
                            new RoleClaim
                            {
                                Id = z.Id,
                                Name = z.Name
                            }).ToList();

                return result;
            }
        }
    }
}
