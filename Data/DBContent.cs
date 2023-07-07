using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CRM_System.Data.Models;

namespace CRM_System.Data {
    public class DBContent : DbContext {

        public DBContent(DbContextOptions<DBContent> options) : base(options) {

        }

        public DbSet<Client> Client { set; get; }
        public DbSet<Order> Order { set; get; }

    }
}
