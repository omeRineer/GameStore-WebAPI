using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Company:User
    {
        public string Name { get; set; }
        public string WebSite { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
