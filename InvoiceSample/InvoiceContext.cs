using InvoiceSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSample
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Invoice>()
                .HasOne(x => x.Customer)
                .WithOne()
                .HasForeignKey<Invoice>(x => x.CustomerId);

            modelBuilder
                .Entity<Invoice>()
                .HasMany(x => x.Items);
        }
    }
}
