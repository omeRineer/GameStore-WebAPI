﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dto
{
    public class UserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
