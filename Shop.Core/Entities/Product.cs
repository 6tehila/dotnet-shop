using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
    // מחלקת מוצר - Product
    // קשר רבים לרבים עם מחלקת Order באמצעות מחלקת ProductOrder
    public class Product
    {
        public int Id { get; set; } // מזהה ייחודי של המוצר
        public string Name { get; set; } // שם המוצר
        public double Price { get; set; } // מחיר המוצר
        public int Quantity { get; set; }
    }
}
