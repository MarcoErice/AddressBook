using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    public interface iTimeProvider
    {
        DateTime Now { get; set; }
    }
}
