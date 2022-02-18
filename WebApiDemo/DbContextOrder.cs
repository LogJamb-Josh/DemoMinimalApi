using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo
{
    public class DbContextOrder : DbContext
    {
        public DbContextOrder(DbContextOptions<DbContextOrder> options) : base(options)        
        {
        
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

    }
}
