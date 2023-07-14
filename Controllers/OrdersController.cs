using CRM_System.Data.Interfaces;
using CRM_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Controllers {
    public class OrdersController : Controller {
        private readonly IOrders _allOrders;

        public OrdersController(IOrders iAllOrders) {
            _allOrders = iAllOrders;
        }

        public ViewResult List() {
            ViewBag.Title = "Заказы";
            OrdersViewModel obj = new OrdersViewModel();
            obj.allOrders = _allOrders.Orders;
            return View(obj);
        }


    }
}
