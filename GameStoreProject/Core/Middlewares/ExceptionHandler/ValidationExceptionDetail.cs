using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middlewares.ExceptionHandler
{
    public class ValidationExceptionDetail : ExceptionDetail
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
