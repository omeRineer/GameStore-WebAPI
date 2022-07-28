using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Game:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DeveloperId { get; set; }
        public int DistributorId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public Company Company { get; set; }
        public Category Category { get; set; }
        public ICollection<GameImage> GameImages { get; set; }
    }
}
