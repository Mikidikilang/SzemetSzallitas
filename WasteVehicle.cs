using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class WasteVehicle
    {
        public int WasteVehicleId { get; set; }
        public string LicensePlate { get; set; }
        public double Capacity { get; set; }
        public double CurrentLoad { get; set; }

        public ICollection<WasteCollection> WasteCollections { get; set; } = new List<WasteCollection>();

        public WasteVehicle(string licensePlate, double capacity)
        {
            LicensePlate = licensePlate;
            Capacity = capacity;
            CurrentLoad = 0.0;
            WasteCollections = new List<WasteCollection>();
        }

        public bool CanCollect(double amount)
        {
            return (CurrentLoad + amount) <= Capacity;
        }
        public void EmptyVehicle()
        {
            CurrentLoad = 0.0;
        }

    }
}
