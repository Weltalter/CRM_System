using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Data.Models {
    public class Order {
        public int orderID { set; get; }
        public string clientID { set; get; }
        public string desc { set; get; }
        public DateTime orderDate { set; get; }
        public ushort price { set; get; }
    }
}
