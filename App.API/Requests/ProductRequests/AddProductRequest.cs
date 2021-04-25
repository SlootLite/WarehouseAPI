using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Requests.ProductRequests
{
    public record AddProductRequest
    {
        [Required]
        [MaxLength(300)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
