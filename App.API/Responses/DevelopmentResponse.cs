using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Responses
{
    public record DevelopmentResponse : BaseResponse
    {
        public string StackTrace { get; init; }
    }
}
