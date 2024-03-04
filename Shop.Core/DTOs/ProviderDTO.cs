using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DTOs
{
    public class ProviderDTO
    {
        public int Id { get; set; } // מזהה ייחודי של הספק
        public string Name { get; set; } // שם הספק
        public string City { get; set; } // עיר מגוריו של הספק
    }
}
