using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    }
}
