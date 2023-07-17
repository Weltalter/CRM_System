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
            bool isClientExists = DBObject.IsTableExist(_content, Order.clientID, 1);

            if (isClientExists)
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
            else{
                var errorResponse = new
                {
                    error = "Клиент с указанным ID не существует"
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPost]
        public ActionResult RemoveOrder([FromBody] int OrderID)
        {
            bool isOrderExists = DBObject.IsTableExist(_content, OrderID, 2);

            if (isOrderExists)
            {
                int RemoveOrderID = OrderID;
                DBObject.RemoveOrder(_content, RemoveOrderID);
                return Json(RemoveOrderID);
            }
            else
            {
                var errorResponse = new
                {
                    error = "Заказ с указанным ID не существует"
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPost]
        public ActionResult RemoveClient([FromBody] int ClientID)
        {
            bool isClientExists = DBObject.IsTableExist(_content, ClientID, 1);

            if (isClientExists)  {
                int RemoveClientID = ClientID;
                DBObject.RemoveClient(_content, RemoveClientID);
                return Json(RemoveClientID);
            }
            else  {
                var errorResponse = new
                {
                    error = "Клиент с указанным ID не существует"
                };
                return BadRequest(errorResponse);
            }
        }
        [HttpPost]
        public ActionResult ChangeClient([FromBody] Client Client)
        {
            Client newClient = new Client()
            {
                clientID = Client.clientID,
                firstName = Client.firstName,
                middleName = Client.middleName,
                lastName = Client.lastName,
                birthdate = Client.birthdate
            };
            bool isClientExists = DBObject.IsTableExist(_content, newClient.clientID, 1);

            if (isClientExists)
            {

                DBObject.ChangeClient(_content, newClient);
                return Json(newClient);
            }
            else
            {
                var errorResponse = new
                {
                    error = "Клиент с указанным ID не существует"
                };
                return BadRequest(errorResponse);
            }
        }
        [HttpPost]
        public ActionResult ChangeOrder([FromBody] Order Order)
        {
            Order newOrder = new Order()
            {
                orderID = Order.orderID,
                clientID = Order.clientID,
                desc = Order.desc,
                orderDate = Order.orderDate,
                price = Order.price
            };
            bool isOrderExists = DBObject.IsTableExist(_content, newOrder.orderID, 2);
            bool isClientExists = DBObject.IsTableExist(_content, newOrder.clientID, 1);

            if (isOrderExists&&isClientExists)
            {
                DBObject.ChangeOrder(_content, newOrder);
                return Json(newOrder);
            }
            else
            {
                var errorResponse = new
                {
                    error = "Заказ или клиент с указанным ID не существует"
                };
                return BadRequest(errorResponse);
            }
        }
    }
}