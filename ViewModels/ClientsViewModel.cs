using CRM_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.ViewModels {
    public class ClientsViewModel {
        public IEnumerable<Client> allClients { set; get; }
        public IEnumerable<Client> sortClients { set; get; }


    }
}
