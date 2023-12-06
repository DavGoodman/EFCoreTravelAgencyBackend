using Microsoft.EntityFrameworkCore;

namespace Onyx_Tasks.Models.seeding
{
    public class InitialSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var JamesMcGill = new TravelAgentInfo() { TravelAgent = "James McGill" };
            var HowardHamlin = new TravelAgentInfo() { TravelAgent = "Howard Hamlin" };
            var ChuckMcGill = new TravelAgentInfo() { TravelAgent = "Chuck McGill" };
            var KimWexler = new TravelAgentInfo() { TravelAgent = "Kim Wexler" };

            // add invoice id
            List<Observation> observations = new List<Observation>
            {
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "Walter White", TravelAgent = JamesMcGill.TravelAgent,
                    NumberOfNights = 5
                },
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "Walter White", TravelAgent = JamesMcGill.TravelAgent,
                    NumberOfNights = 3
                },
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "John Smith", TravelAgent = KimWexler.TravelAgent,
                    NumberOfNights = 14
                },
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "Michael Ehrmantraut", TravelAgent = HowardHamlin.TravelAgent,
                    NumberOfNights = 30
                },
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "Gustavo Fring", TravelAgent = HowardHamlin.TravelAgent,
                    NumberOfNights = 14
                },
                new Observation()
                {
                    Id = Guid.NewGuid(), GuestName = "Gustavo Fring", TravelAgent = JamesMcGill.TravelAgent,
                    NumberOfNights = 5
                }
            };


            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice() { Id = Guid.NewGuid() },
                new Invoice() { Id = Guid.NewGuid() },
                new Invoice() { Id = Guid.NewGuid() },
                new Invoice() { Id = Guid.NewGuid() }
            };

            List<InvoiceGroup> invoiceGroups = new List<InvoiceGroup>
            {
                new InvoiceGroup() { Id = Guid.NewGuid(), IssueDate = new DateTime(2015, 6, 3)},
                new InvoiceGroup() { Id = Guid.NewGuid(), IssueDate = new DateTime(2015, 2, 11)},
                new InvoiceGroup() { Id = Guid.NewGuid(), IssueDate = new DateTime(2016, 11, 21)},
            };



            JamesMcGill.TotalNumberOfNights = observations.Where(o => o.TravelAgent == JamesMcGill.TravelAgent).Sum(o => o.NumberOfNights);
            HowardHamlin.TotalNumberOfNights = observations.Where(o => o.TravelAgent == HowardHamlin.TravelAgent).Sum(o => o.NumberOfNights);
            ChuckMcGill.TotalNumberOfNights = observations.Where(o => o.TravelAgent == ChuckMcGill.TravelAgent).Sum(o => o.NumberOfNights);
            KimWexler.TotalNumberOfNights = observations.Where(o => o.TravelAgent == KimWexler.TravelAgent).Sum(o => o.NumberOfNights);

            observations[0].InvoiceId = invoices[0].Id;
            observations[1].InvoiceId = invoices[0].Id;
            observations[2].InvoiceId = invoices[1].Id;
            observations[3].InvoiceId = invoices[2].Id;
            observations[4].InvoiceId = invoices[3].Id;
            observations[5].InvoiceId = invoices[3].Id;


            List<InvoiceGroupLink> invoiceGroupLinks = new List<InvoiceGroupLink>
            {
                new InvoiceGroupLink() { InvoiceId = invoices[0].Id, InvoiceGroupId = invoiceGroups[0].Id },
                new InvoiceGroupLink() { InvoiceId = invoices[1].Id, InvoiceGroupId = invoiceGroups[0].Id },

                new InvoiceGroupLink() { InvoiceId = invoices[0].Id, InvoiceGroupId = invoiceGroups[1].Id },
                new InvoiceGroupLink() { InvoiceId = invoices[2].Id, InvoiceGroupId = invoiceGroups[1].Id },
                new InvoiceGroupLink() { InvoiceId = invoices[3].Id, InvoiceGroupId = invoiceGroups[1].Id },


                new InvoiceGroupLink() { InvoiceId = invoices[1].Id, InvoiceGroupId = invoiceGroups[2].Id },
                new InvoiceGroupLink() { InvoiceId = invoices[2].Id, InvoiceGroupId = invoiceGroups[2].Id },
                new InvoiceGroupLink() { InvoiceId = invoices[3].Id, InvoiceGroupId = invoiceGroups[2].Id }
            };


            modelBuilder.Entity<TravelAgentInfo>()
                .HasData(JamesMcGill, ChuckMcGill, KimWexler, HowardHamlin);

            foreach (Observation observation in observations)
            {
                modelBuilder.Entity<Observation>()
                    .HasData(observation);
            }

            foreach (Invoice invoice in invoices)
            {
                modelBuilder.Entity<Invoice>()
                    .HasData(invoice);
            }

            foreach (InvoiceGroup invoiceGroup in invoiceGroups)
            {
                modelBuilder.Entity<InvoiceGroup>()
                    .HasData(invoiceGroup);
            }

            foreach (InvoiceGroupLink invoiceGroupLink in invoiceGroupLinks)
            {
                modelBuilder.Entity<InvoiceGroupLink>()
                    .HasData(invoiceGroupLink);
            }







        }
    }
}
