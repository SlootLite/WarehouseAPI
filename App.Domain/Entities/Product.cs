using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<Warehouse> _warehouses = new List<Warehouse>();
        public IReadOnlyCollection<Warehouse> Warehouses => _warehouses.AsReadOnly();
    }
}
