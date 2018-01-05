using AddressBook.Models;
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

            var aPerson = new Person
            {
                FirstName = "Marco",
                LastName = "Erice",
                Phone = "076-213 59 21",
                Email = "marco.erice@gmail.com"
            };
            var bPerson = new Person
            {
                FirstName = "Amin",
                LastName = "Zare",
                Phone = "070-123 45 67",
                Email = "amin.zare@yahoo.com"
            };
            context.People.AddRange(aPerson);
            context.People.AddRange(bPerson);
            //context.SaveChanges();

            // Look for any Addresses.
            if (context.Addresses.Any())
            {
                return;   // DB has been seeded
            }
            context.Addresses.AddRange(
                new Address
                {
                    Description = "abc@def.se",
                    Person = aPerson
                },
                new Address
                {
                    Description = "Tullgränd 2, 123 45  Stockholm",
                    Person = aPerson
                }
            );
            context.SaveChanges();
        }
    }
}
