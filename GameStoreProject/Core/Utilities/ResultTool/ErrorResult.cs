using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.ResultTool
{
    public class ErrorResult : Result, IResult
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
