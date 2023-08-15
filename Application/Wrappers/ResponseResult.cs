using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    //El recomendado para tener responses uniformes
    public record ResponseResult<DataResponse>(bool IsSusses,string? message,DataResponse? result, object?[]errors)
    {
    }
}
