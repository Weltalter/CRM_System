using CRM_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.ViewModels {
    public class OrdersViewModel {
        public IEnumerable<Order> allOrders { set; get; }
    }
}
