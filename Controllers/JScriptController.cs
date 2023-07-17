using CRM_System.Data.Models;
using CRM_System.Data;
using CRM_System.Data.Interfaces;
using CRM_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;

namespace CRM_System.Controllers
{
    public class JScriptController : Controller
    {
        private DBContent _content;

        public JScriptController(DBContent _content)
        {
            this._content = _content;
        }

        [HttpPost]
        public ActionResult AddClient([FromBody] Client Client)
        {
            Client newClient = new Client()
            {
                firstName = Client.firstName,
                middleName = Client.middleName,
                lastName = Client.lastName,
                birthdate = Client.birthdate
            };
            DBObject.AddClient(_content, newClient);
            return Json(newClient);
        }

        [HttpPost]
        public ActionResult AddOrder([FromBody] Order Order)
        {
            Order newOrder = new Order()
            {
                clientID = Order.clientID,
                desc = Order.desc,
                orderDate = Order.orderDate,
                price = Order.price
            };
            DBObject.AddOrder(_content, newOrder);
            return Json(newOrder);
        }

        [HttpPost]
        public ActionResult RemoveOrder([FromBody] int OrderID)
        {
            int RemoveOrderID = OrderID;
            DBObject.RemoveOrder(_content, RemoveOrderID);
            return Json(RemoveOrderID);
        }

        [HttpPost]
        public ActionResult RemoveClient([FromBody] int ClientID)
        {
            int RemoveClientID = ClientID;
            DBObject.RemoveClient(_content, RemoveClientID);
            return Json(RemoveClientID);
        }
    }
}