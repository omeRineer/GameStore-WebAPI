using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class RoleClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserRoleClaim> UserRoleClaims { get; set; }
    }
}
