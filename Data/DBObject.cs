using CRM_System.Controllers;
using CRM_System.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_System.Data {
    public class DBObject {
        public static void Initial (DBContent _content) {
            if (!_content.Client.Any()) {
                _content.Client.AddRange(Clients.Values);
            }

            if (!_content.Order.Any()) {
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

        public static void AddClient (DBContent _content, Client _newClient) {
            _content.Client.Add(_newClient);
            _content.SaveChanges();
        }
        public static void AddOrder (DBContent _content, Order _newOrder) {
            _content.Order.Add(_newOrder);
            _content.SaveChanges();
        }
        public static void RemoveClient(DBContent _content, int RemoveClientID) {
            Client _removeClient = _content.Client
               .Where(o => o.clientID == RemoveClientID)
               .FirstOrDefault();


            _content.Client.Remove(_removeClient);
            _content.SaveChanges();
        }
        public static void RemoveOrder(DBContent _content, int RemoveOrderID) {
            Order _removeOrder = _content.Order
               .Where(o => o.orderID == RemoveOrderID)
               .FirstOrDefault();


            _content.Order.Remove(_removeOrder);
            _content.SaveChanges();
        }
        public static void ChangeClient(DBContent _content, Client _newClient) {
            Client _changeClient = _content.Client
               .Where(o => o.clientID == _newClient.clientID)
               .FirstOrDefault();

            if (_changeClient != null) {
                    _changeClient.firstName = _newClient.firstName;
                    _changeClient.middleName = _newClient.middleName;
                    _changeClient.lastName = _newClient.lastName;
                    _changeClient.birthdate = _newClient.birthdate;        
            }
            _content.SaveChanges();
        }
        public static void ChangeOrder(DBContent _content, Order _newOrder) {
            Order _changeOrder = _content.Order
               .Where(o => o.orderID == _newOrder.orderID)
               .FirstOrDefault();

            if (_changeOrder != null) {     
                _changeOrder.clientID = _newOrder.clientID;
                _changeOrder.desc = _newOrder.desc;
                _changeOrder.orderDate = _newOrder.orderDate;
                _changeOrder.price = _newOrder.price;
            }

            _content.SaveChanges();
        }

        public static bool IsTableExist(DBContent _content, int Id, int Table) {
            //Table:1 - клиента
            //Table:2 - заказы
            bool isTableExists = false;
            if (Table == 1) {
                isTableExists = _content.Client.Any(c => c.clientID == Id);
            }
            else if (Table == 2) {
                isTableExists = _content.Order.Any(c => c.orderID == Id);
            }

            return isTableExists;
        }
    }
}
