using Facturation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Datas
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Puissance> Puissance { get; set; }
        public DbSet<Tva> Tva { get; set; }
        public DbSet<Abonnement> Abonnement { get; set; }
        public DbSet<Facturations> Facturations { get; set; }
        

    }
}
