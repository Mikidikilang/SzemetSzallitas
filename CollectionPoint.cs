using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class CollectionPoint
    {
        public int CollectionPointId { get; set; }
        public string Address { get; set; }
        public double MaxCapatity { get; set; }
        public double CurrentWaste { get; set; }

        // Foreign key
        public int SettlementId { get; set; }

        // Navigációs tulajdonságok
        public Settlement Settlement { get; set; }
        public ICollection<WasteDeposit> WasteDeposits { get; set; } = new List<WasteDeposit>();
        public ICollection<WasteCollection> WasteCollections { get; set; } = new List<WasteCollection>();

        public CollectionPoint(string address, double maxCapacity)
        {
            Address = address;
            MaxCapatity = maxCapacity;
            CurrentWaste = 0.0;
            WasteDeposits = new List<WasteDeposit>();
            WasteCollections = new List<WasteCollection>(); 
        }

        public double GetAvailableCapacity()
        {
            return MaxCapatity - CurrentWaste;
        }
        public bool IsFull()
        {
            return CurrentWaste >= MaxCapatity;
        }
    }
}
