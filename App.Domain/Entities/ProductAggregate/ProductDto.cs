using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.ProductAggregate
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
