using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using megaDesk_Web.Models;

    public class MegaDeskWebContext : DbContext
    {
        public MegaDeskWebContext (DbContextOptions<MegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<megaDesk_Web.Models.DeskQuote> DeskQuote { get; set; }
        public DbSet<megaDesk_Web.Models.Desk> Desk { get; set; }
        public DbSet<megaDesk_Web.Models.DesktopMaterial> DesktopMaterial { get; set; }
        public DbSet<megaDesk_Web.Models.Delivery> Delivery { get; set; }
    }
