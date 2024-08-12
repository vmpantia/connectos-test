using ACME.Domain.Data.Stubs;
using ACME.Domain.Models.Entities;
using ACME.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ACME.Infrastructure.Database.Contexts
{
    public class ACMEDbContext : DbContext
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<Address> _addresses = new List<Address>();
        private readonly List<Subscription> _subscriptions = new List<Subscription>();
        private readonly List<Country> _countries = new List<Country>();
        private readonly List<Magazine> _magazines = new List<Magazine>();
        private readonly List<Publication> _publications = new List<Publication>();
        private readonly List<PrintDistributor> _printDistributors = new List<PrintDistributor>();
        public ACMEDbContext(DbContextOptions<ACMEDbContext> options) : base(options)
        {
            _customers = MockData.MockCustomer().Generate(50);
            _countries = MockData.MockCountry().Generate(20);
            _magazines = MockData.MockMagazine().Generate(300);
            _addresses = MockData.MockAddress(_customers.Select(data => data.Id),
                                              _countries.Select(data => data.Id))
                                 .Generate(60);
            _publications = MockData.MockPublication(_countries.Select(data => data.Id))
                                    .Generate(20);

            // Generate subscriptions mock data
            foreach (var customer in _customers)
            {
                var customerAddresses = _addresses.Where(data => data.CustomerId == customer.Id)
                                                  .ToList();

                foreach (var customerAddress in customerAddresses)
                {
                    var subscription = MockData.MockSubscription(customer.Id,
                                                                 customerAddress.Id,
                                                                 _magazines.Select(data => data.Id))
                                               .Generate();
                    _subscriptions.Add(subscription);
                }
            }

            // Generate print distributors mock data
            foreach (var publication in _publications)
            {
                var distributor = MockData.MockPrintDistributor(publication.Id).Generate();
                _printDistributors.Add(distributor);
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(cstmr =>
            {
                cstmr.HasMany(prop => prop.Addresses)
                     .WithOne(prop => prop.Customer)
                     .HasForeignKey(prop => prop.CustomerId)
                     .IsRequired();

                cstmr.HasMany(prop => prop.Subscriptions)
                     .WithOne(prop => prop.Customer)
                     .HasForeignKey(prop => prop.CustomerId)
                     .IsRequired();

                cstmr.HasData(_customers);

                cstmr.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<Address>(addrs =>
            {
                addrs.HasOne(prop => prop.Customer)
                     .WithMany(prop => prop.Addresses)
                     .HasForeignKey(prop => prop.CustomerId)
                     .IsRequired();

                addrs.HasOne(prop => prop.Country)
                     .WithMany(prop => prop.Addresses)
                     .HasForeignKey(prop => prop.CountryId)
                     .IsRequired();

                addrs.HasOne(prop => prop.Subscription)
                     .WithOne(prop => prop.Address)
                     .IsRequired();

                addrs.HasData(_addresses);

                addrs.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<Subscription>(subs =>
            {
                subs.HasOne(prop => prop.Customer)
                     .WithMany(prop => prop.Subscriptions)
                     .HasForeignKey(prop => prop.CustomerId)
                     .OnDelete(DeleteBehavior.Restrict)
                     .IsRequired();

                subs.HasOne(prop => prop.Address)
                    .WithOne(prop => prop.Subscription)
                    .IsRequired();

                subs.HasOne(prop => prop.Magazine)
                    .WithMany(prop => prop.Subscriptions)
                    .HasForeignKey(prop => prop.MagazineId)
                    .IsRequired();

                subs.HasData(_subscriptions);

                subs.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<Country>(cntry =>
            {
                cntry.HasMany(prop => prop.Addresses)
                     .WithOne(prop => prop.Country)
                     .HasForeignKey(prop => prop.CountryId)
                     .IsRequired();

                cntry.HasMany(prop => prop.Publications)
                     .WithOne(prop => prop.Country)
                     .HasForeignKey(prop => prop.CountryId)
                     .IsRequired();

                cntry.HasData(_countries);

                cntry.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<Magazine>(mgzn =>
            {
                mgzn.HasMany(prop => prop.Subscriptions)
                    .WithOne(prop => prop.Magazine)
                    .HasForeignKey(prop => prop.MagazineId)
                    .IsRequired();

                mgzn.HasData(_magazines);

                mgzn.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<Publication>(pblc =>
            {
                pblc.HasOne(prop => prop.Country)
                    .WithMany(prop => prop.Publications)
                    .HasForeignKey(prop => prop.CountryId)
                    .IsRequired();

                pblc.HasOne(prop => prop.PrintDistributor)
                    .WithOne(prop => prop.Publication)
                    .IsRequired();

                pblc.HasData(_publications);

                pblc.HasQueryFilter(data => data.Status != Status.Deleted);
            });

            modelBuilder.Entity<PrintDistributor>(prnt =>
            {
                prnt.HasOne(prop => prop.Publication)
                    .WithOne(prop => prop.PrintDistributor)
                    .IsRequired();

                prnt.HasData(_printDistributors);

                prnt.HasQueryFilter(data => data.Status != Status.Deleted);
            });
        }
    }
}
