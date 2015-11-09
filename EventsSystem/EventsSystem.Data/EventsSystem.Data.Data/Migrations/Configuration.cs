namespace EventsSystem.Data.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;

    public sealed class Configuration : DbMigrationsConfiguration<EventsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventsSystemDbContext context)
        {
            this.SeedAdmins(context);
            this.SeedTowns(context);
            this.SeedEvents(context);
        }

        private void SeedEvents(EventsSystemDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            // seed here
        }

        private void SeedTowns(EventsSystemDbContext context)
        {
            if (context.Towns.Any())
            {
                return;
            }

            // seed here
        }

        private void SeedAdmins(EventsSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var pesho = new User()
            {
                Email = "pesho@gmail.com",
                UserName = "pesho@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("peshopesho")
            };

            context.Users.Add(pesho);

            var gosho = new User()
            {
                Email = "gosho@gmail.com",
                UserName = "gosho@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("goshogosho")
            };

            context.Users.Add(gosho);

            var stamat = new User()
            {
                Email = "stamat@gmail.com",
                UserName = "stamat@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("stamat")
            };

            context.Users.Add(stamat);

            var town = new Town
            {
                Name = "Sofia"
            };

            context.Towns.Add(town);

            context.SaveChanges();

            var cat = new Category
            {
                Name = "Category Name",
                AuthorId = stamat.Id
            };

            context.Categories.Add(cat);

            context.SaveChanges();
            var eventToAdd = new Event
            {
                Name = "Pesho's event",
                CategoryId = cat.Id,
                TownId = town.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ShortDescrtiption = "Short description",
                LongDescrtiption = "Long description",
                IsPrivate = false,
                AuthorId = pesho.Id
            };
            context.Events.Add(eventToAdd);

            context.SaveChanges();
        }
    }
}
