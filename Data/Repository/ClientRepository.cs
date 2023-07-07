using CRM_System.Data.Interfaces;
using CRM_System.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CRM_System.Data.Repository {
    public class ClientRepository : IClients {

        private readonly DBContent _DBContent;

        public ClientRepository(DBContent DBContent) {
            _DBContent = DBContent;
        }

        public IEnumerable<Client> Clients => _DBContent.Client;
        public Client GetClient(int ClientID) => _DBContent.Client.FirstOrDefault(c => c.clientID == ClientID);
    }
}
