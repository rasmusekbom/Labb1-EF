using Microsoft.EntityFrameworkCore;
using RasmusLabb1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RasmusLabb1.Contexts
{
    public class AppDbContext : DbContext
    { 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=msi\sqlexpress;Initial Catalog=leaveapplications;Integrated Security=True;Pooling=False");

        }
    }
}
