using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class WasteDeposit
    {
        public int WasteDepositId { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int CollectionPointId { get; set; }

        // Navigációs tulajdonságok
        public User User { get; set; }
        public CollectionPoint CollectionPoint { get; set; }
        public double Amount { get; set; }
        public string Week { get; set; }
        public DateTime DepositDate { get; set; }
        public WasteDeposit(int userId, int collectionPointId, double amount, string week, DateTime depositDate)
        {
            UserId = userId;
            CollectionPointId = collectionPointId;
            Amount = amount;
            Week = week;
            DepositDate = depositDate;
        }
    }
}
