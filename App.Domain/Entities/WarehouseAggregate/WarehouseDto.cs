﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.WarehouseAggregate
{
    public record WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
