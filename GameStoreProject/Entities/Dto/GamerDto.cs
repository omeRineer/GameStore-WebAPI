using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class GamerDto:UserDto,IDto
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
