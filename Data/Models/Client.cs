using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Data.Models {
    public class Client {
        public int clientID { set; get; }
        public string firstName { set; get; }
        public string middleName { set; get; }
        public string lastName { set; get; }
        public DateTime birthdate { set; get; }
    }
}
