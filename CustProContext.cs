using System;
using Microsoft.EntityFrameworkCore;
using tokentutor.Models;

namespace tokentutor
{
    public class CustomerProductContext : DbContext
    {
        public CustomerProductContext(DbContextOptions<CustomerProductContext> options) : base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}