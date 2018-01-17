using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Translation
    {
        public int TranslationId { get; set; }
        public string CultureCode { get; set; }
        public string Term { get; set; }
        public string TranslatedTerm { get; set; }
    }
}
