using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GameImage:IEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImagePath { get; set; }
        public bool? State { get; set; } = true;

        public virtual Game Game { get; set; }
    }
}
