using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemetSzallitas
{
    class UserService
    {
        private readonly SzemeTechDbContext _context;

        public UserService(SzemeTechDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Visszaadja a felhasználó által leadott összes szemét mennyiségét
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public double GetTotalWasteDeposited(int userId)
        {
            return _context.WasteDeposits
                .Where(wd => wd.UserId == userId)
                .Sum(wd => wd.Amount);
        }

        /// <summary>
        /// Ellenőrzi, hogy a felhasználó adott e már le szemetet az adott héten
        /// </summary>
        /// <param name="usedId"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public bool HasDepositedThisWeek(int usedId, string week)
        {
            return _context.WasteDeposits
                .Any(wd => wd.UsedId == usedId && wd.Week == week);
        }

        /// <summary>
        /// Ellenőrzi, hogy a felhasználó leadhat-e szemetet az aktuális héten
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CanDepositedThisWeek(int userId)
        {
            var currentWeek = GetCurrentWeek();
            return !HasDepositedThisWeek(userId, currentWeek);
        }

        /// <summary>
        /// Visszaadja az aktuális hét azonosítóját
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWeek()
        {
            var now = DateTime.Now;
            var year = now.Year;
            var weekOfYear = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return $"{year}-W{weekOfYear:D2}";
        }

        /// <summary>
        /// Felhasználó keresése id alapján
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            return _context.Users
                .Include(u => u.WasteDeposits)
                .ThenInclude(wd => wd.CollectionPoint)
                .FirstOrDefault(u => u.UserId == userId);
        }

        /// <summary>
        /// Felhasználó keresése név alapján
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserById(string name)
        {
            return _context.Users
                .Include(u => u.WasteDeposits)
                .ThenInclude(wd => wd.CollectionPoint)
                .FirstOrDefault(u => u.Name == name);
        }
    }
}
