using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class WasteCollection
    {
        public int WasteCollectionId { get; set; }

        //Foreign Keys
        public int WasteVehicleId { get; set; }
        public int CollectionPointId { get; set; }

        //navigációs tulajdonságok
        public WasteVehicle WasteVehicle { get; set; }
        public CollectionPoint CollectionPoint { get; set; }

        public double Amount { get; set; }
        public DateTime CollectionDate { get; set; }

        public WasteCollection(int wasteVehicleId, int collectionPointId, double amount, DateTime collectionDate)
        {
            WasteVehicleId = wasteVehicleId;
            CollectionPointId = collectionPointId;
            Amount = amount;
            CollectionDate = collectionDate;
        }
    }
}
