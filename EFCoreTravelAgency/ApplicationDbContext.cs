using Microsoft.EntityFrameworkCore;
using Onyx_Tasks.Models;
using Onyx_Tasks.Models.seeding;

namespace EfCore_Travel_Agency
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TravelAgentInfo>().HasKey(ta => ta.TravelAgent);

            modelBuilder.Entity<Observation>()
                .HasOne(o => o.TravelAgentInfo)
                .WithMany(t => t.Observations)
                .HasForeignKey(o => o.TravelAgent);

            modelBuilder.Entity<InvoiceGroupLink>().HasKey(e => new { e.InvoiceGroupId, e.InvoiceId });



            InitialSeed.Seed(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceGroup> InvoiceGroups { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<TravelAgentInfo> TravelAgentsInfo { get; set; }
        public DbSet<InvoiceGroupLink> InvoiceGroupLinks { get; set;}



    }
}
