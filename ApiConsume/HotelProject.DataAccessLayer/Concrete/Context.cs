﻿using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ProjectDataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public Context()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseSqlServer("Data Source=192.168.1.35;Initial Catalog=ApiDb;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ApiDb; Integrated Security=True; TrustServerCertificate=True");
           



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>()
              .ToTable(tb => tb.HasTrigger("Room"));
            modelBuilder.Entity<Staff>()
              .ToTable(tb => tb.HasTrigger("Staff"));
            modelBuilder.Entity<Guest>()
              .ToTable(tb => tb.HasTrigger("Guest"));
        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<TestiMonial> TestiMonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }


    }
}
