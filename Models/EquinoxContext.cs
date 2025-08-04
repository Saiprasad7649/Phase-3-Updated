using System;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Models
{
    public class EquinoxContext : DbContext
    {
        public EquinoxContext(DbContextOptions<EquinoxContext> options) 
            : base(options) 
        { }

        public DbSet<EquinoxClass> EquinoxClasses      => Set<EquinoxClass>();
        public DbSet<Club> Clubs                        => Set<Club>();
        public DbSet<ClassCategory> ClassCategories     => Set<ClassCategory>();
        public DbSet<User> Users                        => Set<User>();

        // 1) Add the Bookings DbSet
        public DbSet<Booking> Bookings                  => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clubs
            modelBuilder.Entity<Club>().HasData(
                new Club { ClubId = 1, Name = "Chicago Loop", PhoneNumber = "(123) 456-7890" },
                new Club { ClubId = 2, Name = "West Chicago", PhoneNumber = "(987) 654-3210" }
            );

            // Categories
            modelBuilder.Entity<ClassCategory>().HasData(
                new ClassCategory { ClassCategoryId = 1, Name = "Yoga" },
                new ClassCategory { ClassCategoryId = 2, Name = "HIIT" },
                new ClassCategory { ClassCategoryId = 3, Name = "Cardio" },
                new ClassCategory { ClassCategoryId = 4, Name = "Strength" }
            );

            // Users (Coaches)
            modelBuilder.Entity<User>().HasData(
                new User {
                    UserId      = "coach1",
                    Name        = "Jane Coach",
                    PhoneNumber = "(555) 123-4567",
                    Email       = "jane@example.com",
                    DOB         = new DateTime(1990, 1, 1),
                    IsCoach     = true
                },
                new User {
                    UserId      = "coach2",
                    Name        = "Sarah",
                    PhoneNumber = "(555) 234-5678",
                    Email       = "sarah@example.com",
                    DOB         = new DateTime(1988, 2, 2),
                    IsCoach     = true
                },
                new User {
                    UserId      = "coach3",
                    Name        = "George",
                    PhoneNumber = "(555) 345-6789",
                    Email       = "george@example.com",
                    DOB         = new DateTime(1985, 3, 3),
                    IsCoach     = true
                },
                new User {
                    UserId      = "coach4",
                    Name        = "Henry",
                    PhoneNumber = "(555) 456-7890",
                    Email       = "henry@example.com",
                    DOB         = new DateTime(1982, 4, 4),
                    IsCoach     = true
                },
                new User {
                    UserId      = "coach5",
                    Name        = "Lena",
                    PhoneNumber = "(555) 567-8901",
                    Email       = "lena@example.com",
                    DOB         = new DateTime(1991, 5, 5),
                    IsCoach     = true
                }
            );

            // Classes
            modelBuilder.Entity<EquinoxClass>().HasData(
                new {
                    EquinoxClassId  = 1,
                    Name             = "Morning Yoga",
                    ClassPicture     = "yoga2.jpg",
                    ClassDay         = "Monday",
                    Time             = "8 AM – 9 AM",
                    ClassCategoryId  = 1,
                    ClubId           = 1,
                    UserId           = "coach1"
                },
                new {
                    EquinoxClassId  = 2,
                    Name             = "Power HIIT",
                    ClassPicture     = "hiit1.jpg",
                    ClassDay         = "Wednesday",
                    Time             = "6 PM – 7 PM",
                    ClassCategoryId  = 2,
                    ClubId           = 2,
                    UserId           = "coach1"
                },
                new {
                    EquinoxClassId  = 3,
                    Name             = "Cardio Blast",
                    ClassPicture     = "barre-fusion.jpg",
                    ClassDay         = "Friday",
                    Time             = "7 AM – 8 AM",
                    ClassCategoryId  = 3,
                    ClubId           = 1,
                    UserId           = "coach2"
                },
                new {
                    EquinoxClassId  = 4,
                    Name             = "Strength Training",
                    ClassPicture     = "strength-training.jpg",
                    ClassDay         = "Saturday",
                    Time             = "10 AM – 11 AM",
                    ClassCategoryId  = 4,
                    ClubId           = 2,
                    UserId           = "coach3"
                },
                new {
                    EquinoxClassId  = 5,
                    Name             = "Yoga 202",
                    ClassPicture     = "hatha-yoga.jpg",
                    ClassDay         = "Sunday",
                    Time             = "5 PM – 6 PM",
                    ClassCategoryId  = 1,
                    ClubId           = 1,
                    UserId           = "coach4"
                },
                new {
                    EquinoxClassId  = 6,
                    Name             = "Power Yoga",
                    ClassPicture     = "boxing-101.jpg",
                    ClassDay         = "Sunday",
                    Time             = "3 PM – 4 PM",
                    ClassCategoryId  = 1,
                    ClubId           = 1,
                    UserId           = "coach5"
                }
            );

            // 2) Seed a couple of sample bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId = 1, EquinoxClassId = 1 },
                new Booking { BookingId = 2, EquinoxClassId = 2 }
            );

            // Configure User-EquinoxClass relationship to allow deletion
            modelBuilder.Entity<EquinoxClass>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull); // Set UserId to null when User is deleted
        }
    }
}
