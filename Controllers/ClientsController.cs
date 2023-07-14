using CRM_System.Data.Interfaces;
using CRM_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Controllers {
    public class ClientsController : Controller {
        private readonly IClients _allClients;

        public ClientsController(IClients iAllClients) {
            _allClients = iAllClients;
        }

        public ViewResult List() {
            ViewBag.Title = "Клиенты";
            ClientsViewModel obj = new ClientsViewModel();
            obj.allClients = _allClients.Clients;

            return View(obj);
        }
        public ViewResult OrderList() {
            ViewBag.Title = "Клиенты";
            ClientsViewModel obj = new ClientsViewModel();
            obj.sortClients = _allClients.Clients.OrderBy(c => c.clientID);

            return View(obj);
        }

    }
}
