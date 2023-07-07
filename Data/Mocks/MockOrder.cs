using System;
using CRM_System.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_System.Data.Models;

namespace CRM_System.Data.Mocks {
    public class MockOrder : IOrders {
        public IEnumerable<Order> Orders {
            get {
                return new List<Order> {
                    new Order { desc = "ASAS"},
                    new Order { desc = "BSBS"}
                };
            }
        }
    }
}
