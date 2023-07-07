using CRM_System.Data.Interfaces;
using CRM_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Data.Mocks {
    public class MockClients : IClients {

        private readonly IOrders _Orders = new MockOrder();

        public IEnumerable<Client> Clients {
            get {
                return new List<Client> {
                    new Client {firstName = "Роман", middleName = "Крылов", lastName = "Алексеевич", birthdate = DateTime.Now},
                    new Client {firstName = "Роман", middleName = "Крылов", lastName = "Алексеевич", birthdate = DateTime.Now},
                    new Client {firstName = "Роман", middleName = "Крылов", lastName = "Алексеевич", birthdate = DateTime.Now}
                };
            }
        }


        public Client GetClient(int ClientID) {
            throw new NotImplementedException();
        }
    }
}
