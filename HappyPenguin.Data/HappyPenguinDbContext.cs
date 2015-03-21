using HappyPenguin.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data
{
    public class HappyPenguinDbContext : IdentityDbContext<ApplicationUser>
    {
        public HappyPenguinDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<HappyShopper> Shoppers { get; set; }
        public DbSet<HappyCart> Carts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<RecentlyBought> RecentlyBoughtItems { get; set; }
        public static HappyPenguinDbContext Create()
        {
            return new HappyPenguinDbContext();
        }
    }
}
