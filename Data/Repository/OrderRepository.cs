using CRM_System.Data.Interfaces;
using CRM_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRM_System.Data.Repository {
    public class OrderRepository : IOrders {

        private readonly DBContent _DBContent;

        public OrderRepository(DBContent DBContent) {
            _DBContent = DBContent;
        }

        public IEnumerable<Order> Orders => _DBContent.Order;
    }
}
