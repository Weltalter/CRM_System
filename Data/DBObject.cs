using CRM_System.Controllers;
using CRM_System.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_System.Data {
    public class DBObject {
        public static void Initial(DBContent _content) {
            if(!_content.Client.Any()) {
                _content.Client.AddRange(Clients.Values);
            }

            if(!_content.Order.Any()) {
                _content.Order.AddRange(Orders.Values);
            }

            _content.SaveChanges();
        }

        private static Dictionary<string, Client> _clients;
        public static Dictionary<string, Client> Clients {
            get {
                if (_clients == null) {
                    _clients = new Dictionary<string, Client> {
                        { "Администратор", new Client { firstName = "Роман", middleName = "Крылов", lastName = "Алексеевич", birthdate = DateTime.Now } }
                    };
                }
                return _clients;
            }
        }

        private static Dictionary<string, Order> _orders;
        public static Dictionary<string, Order> Orders {
            get {
                if (_orders == null) {
                    _orders = new Dictionary<string, Order> {
                        { "Заказ 001", new Order { clientID = 1, desc = "Тестовый заказ", orderDate = DateTime.Now, price = 1 } }
                    };
                }
                return _orders;
            }
        }






    }
}
