using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.ResultTool
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
