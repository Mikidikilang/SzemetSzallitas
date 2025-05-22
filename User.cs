using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    public enum UserRole
    {
        Resident, 
        Admin
    }

    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public ICollection<WasteDeposit> WateDeposits { get; set; } = new List<WasteDeposit>();
        public User(string name, UserRole role)
        {
            Name = name;
            Role = role;
            WateDeposits = new List<WasteDeposit>();
        }
    }
}
