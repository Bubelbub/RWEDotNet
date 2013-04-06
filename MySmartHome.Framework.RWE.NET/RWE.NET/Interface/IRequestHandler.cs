using RWE.NET.Request;
using RWE.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Interface
{
    public interface IRequestHandler
    {
        TResponse RequestResponse<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest, new()
            where TResponse : BaseResponse, new();

        NotificationList RequestUpdate();
    }
}
