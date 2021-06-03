using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pivot> Pivots { get; set; }

        public Film Film
        {
            get => default;
            set
            {
            }
        }

        public Code Code
        {
            get => default;
            set
            {
            }
        }

        public Order Order
        {
            get => default;
            set
            {
            }
        }

        public Ticket Ticket
        {
            get => default;
            set
            {
            }
        }

        public Session Session
        {
            get => default;
            set
            {
            }
        }

        public Card Card
        {
            get => default;
            set
            {
            }
        }

        public Category Category
        {
            get => default;
            set
            {
            }
        }

        public Hall Hall
        {
            get => default;
            set
            {
            }
        }

        public User User
        {
            get => default;
            set
            {
            }
        }

        public Place Place
        {
            get => default;
            set
            {
            }
        }

        public Pivot Pivot
        {
            get => default;
            set
            {
            }
        }
    }
}