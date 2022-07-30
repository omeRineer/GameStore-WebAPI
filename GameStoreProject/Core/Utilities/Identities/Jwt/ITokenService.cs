using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Identities.Jwt
{
    public interface ITokenService
    {
        AccessToken GenerateToken(User user, List<RoleClaim> roleClaims);
    }
}
