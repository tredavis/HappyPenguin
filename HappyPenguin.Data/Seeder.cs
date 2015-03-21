using HappyPenguin.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data
{
    public static class Seeder
    {
        public static void Seed(HappyPenguinDbContext context)
        {
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            ApplicationUser bgoo = manager.FindByEmail("brandon.goo12@yahoo.com");

            if (bgoo == null)
            {
                bgoo = new ApplicationUser
                {
                    Email = "brandon.goo@yahoo.com",
                    UserName = "Brandon Goo"
                };
                manager.Create(bgoo, "123456");
            }

            ApplicationUser dwoon = manager.FindByEmail("ziinq@yahoo.com");
            if (dwoon == null)
            {

                dwoon = new ApplicationUser
                {
                    Email = "ziinq@yahoo.com",
                    UserName = "Darrett Woon"
                };
                manager.Create(dwoon, "123456");

            }

            ApplicationUser tdavis = manager.FindByEmail("tredavis.developer@gmail.com");
            if (tdavis == null)
            {
                tdavis = new ApplicationUser
                {
                    Email = "tredavis.developer@gmail.com",
                    UserName = "Tre Davis"
                };
                manager.Create(tdavis, "123456");
            }
            context.Items.AddOrUpdate(m => m.ItemName,
                   new Item
                   {
                       Image = "http://www.online-image-editor.com//styles/2014/images/example_image.png",
                       ItemName = "Test Item",
                       Price = 125m
                   });

        }
    }
}
