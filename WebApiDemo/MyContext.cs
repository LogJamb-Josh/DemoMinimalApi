using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)        
        {
        
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

    }
}
