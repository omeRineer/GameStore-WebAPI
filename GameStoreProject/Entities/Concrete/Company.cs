using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Company:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
