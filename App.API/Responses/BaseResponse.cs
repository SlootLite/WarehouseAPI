using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Responses
{
    public record BaseResponse
    {
        public string ErrorMessage { get; init; }
    }
}
