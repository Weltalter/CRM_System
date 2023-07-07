using CRM_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Data.Interfaces {
    public interface IClients {
        IEnumerable<Client> Clients { get; }
        Client GetClient(int ClientID);
    }
}
