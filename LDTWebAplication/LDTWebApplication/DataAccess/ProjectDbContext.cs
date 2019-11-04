using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<UserEvents>().HasKey(op => new { op.UserId, op.ID });


            model.Entity<User>()
                .HasMany(x => x.UserEvents)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            model.Entity<Event>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserEvents)
                .HasForeignKey(x => x.UserId);
                


            model.Entity<User>()
                .HasData(
                new User
                {
                    ID = 1,
                    Firstname = "Filip",
                    Lastname = "Donevski",
                    Email = "filip.Donevski1@gmail.com",
                    Username = "Done",
                    Password = "Done123",
                    Address = "Mirce Acev18",
                    City = "Kumanovo",
                    Country = "Macedonia",
                    DateOfBirth = "12.12.1990",
                },
                 new User
                 {
                     ID = 2,
                     Firstname = "Nikolina",
                     Lastname = "Donevska",
                     Email = "Niakolin.Donevskia@gmail.com",
                     Username = "Nane",
                     Password = "Nane123",
                     Address = "Mirce Acev18",
                     City = "Kumanovo",
                     Country = "Macedonia",
                     DateOfBirth = "12.12.1990",
                 }
                );

            model.Entity<Event>()
                .HasData(
                new Event
                {
                    Id = 1,
                    EventDiscription = "Race to the top of the mountain Vodno, with price pool for first, second and third place.",
                    EventDuration = 12,
                    EventLocation = "Kumanovo",
                    EventName = "Ture De Kumanovo",
                    EventOpenPleaces = 54,
                    EventStart = "24.12.2019",
                    EventType = DomainModels.Enum.EventTypeEnums.Sport,
                    UserId = 1
                },
                 new Event
                 {
                     Id = 2,
                     EventDiscription = "Race to the top of the mountain Vodno, with price pool for first, second and third place.",
                     EventDuration = 12,
                     EventLocation = "Skopje",
                     EventName = "Skopje De Kumanovo",
                     EventOpenPleaces = 54,
                     EventStart = "12.12.2019",
                     EventType = DomainModels.Enum.EventTypeEnums.Education,
              UserId =2
                 }

                );

            model.Entity<UserEvents>()
                .HasData(
                new UserEvents
                {
                    ID = 1,
                    CreatedEventId = 1,
                    UserId = 1,
                },
                  new UserEvents
                  {
                      ID = 2,
                      UserId = 1,
                      GoingEventId = 2
                  });
        }
    }
}
