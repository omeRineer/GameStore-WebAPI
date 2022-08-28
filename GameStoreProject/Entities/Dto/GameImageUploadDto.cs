using Core.Entities.Abstract;
using Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class GameImageUploadDto:IDto
    {
        public int GameId { get; set; }
        public IFormFileCollection FileCollection { get; set; }
    }
}
