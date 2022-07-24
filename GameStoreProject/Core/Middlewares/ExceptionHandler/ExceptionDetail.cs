using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middlewares.ExceptionHandler
{
    public class ExceptionDetail
    {
        public string Type { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
