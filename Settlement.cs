using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class Settlement
    {
        public int SettlementId { get; set; }
        public string Name { get; set; }

        //Navigációs tulajdonságok
        public ICollection<CollectionPoint> CollectionPoints { get; set; } = new List<CollectionPoint>();

        public Settlement(string name)
        {
            Name = name;
            CollectionPoints = new List<CollectionPoint>();
        }
    }
}
