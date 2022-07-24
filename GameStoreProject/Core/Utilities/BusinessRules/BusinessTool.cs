using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRules
{
    public static class BusinessTool
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (IResult result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return new SuccessResult();
        }
    }
}
