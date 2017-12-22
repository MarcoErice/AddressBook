using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any People.
            if (context.People.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}
