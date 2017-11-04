using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlowOut.Models;
using System.Data.Entity;

namespace BlowOut.DAL
{
    public class BLOWOUTContext : DbContext
    {
        public BLOWOUTContext() : base("BLOWOUTContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}