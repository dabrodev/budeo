using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budeo
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public int Weight { get; set; } 

        public string City { get; set; }

        public Dimension Dimension { get; set; }   
        
        public Location Location { get; set; }
    }
}
