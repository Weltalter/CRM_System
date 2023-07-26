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
        public ViewResult AddRecord() {
            ViewBag.Title = "Добавить заказ";

            return View();
        }
        public ViewResult ChangeRecord() {
            ViewBag.Title = "Изменить заказ";

            return View();
        }
        public ViewResult DeleteRecord() {
            ViewBag.Title = "Удалить заказ";

            return View();
        }

    }
}
