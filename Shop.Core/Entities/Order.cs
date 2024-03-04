using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
    // מחלקת הזמנה - Order
    // קשר רבים לרבים עם מחלקת Product באמצעות מחלקת ProductOrder
    // קשר יחיד ליחיד עם מחלקת Provider
    public class Order
    {
      
        public int Id { get; set; }
        public int SumOrder { get; set; }
        public List<Product> Products { get; set; }

        //one-to-one מפתח זר
        public Provider Provider { get; set; }

    }
}
