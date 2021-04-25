using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Requests.WarehouseRequests
{
    public record ModifyWarehouseItemRequest
    {
        [Required]
        public int Quantity { get; set; }
    }
}
