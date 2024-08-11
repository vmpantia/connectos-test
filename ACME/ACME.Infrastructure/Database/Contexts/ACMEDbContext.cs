using ACME.Domain.Data.Stubs;
using ACME.Domain.Models.Entities;
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
        public ACMEDbContext(DbContextOptions options) : base(options)
        {
            _customers = MockData.MockCustomer().Generate(20);
            _countries = MockData.MockCountry().Generate(10);
            _magazines = MockData.MockMagazine().Generate(100);
            _addresses = MockData.MockAddress(_customers.Select(data => data.Id), 
                                              _countries.Select(data => data.Id))
                                 .Generate(20);
            _publications = MockData.MockPublication(_countries.Select(data => data.Id))
                                    .Generate(5);
            foreach (var customer in _customers)
            {
                var customerAddresses = _addresses.Where(data => data.CustomerId == customer.Id)
                                                  .ToList();

                if (customerAddresses.Any())
                {
                    var subscriptions = MockData.MockSubscription(customer.Id, 
                                                                  customerAddresses.Select(data => data.Id),
                                                                  _magazines.Select(data => data.Id))
                                                .Generate(20);
                    _subscriptions.AddRange(subscriptions);
                }
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
            });

            modelBuilder.Entity<Subscription>(subs =>
            {
                subs.HasOne(prop => prop.Customer)
                     .WithMany(prop => prop.Subscriptions)
                     .HasForeignKey(prop => prop.CustomerId)
                     .IsRequired();

                subs.HasOne(prop => prop.Address)
                    .WithOne(prop => prop.Subscription)
                    .IsRequired();

                subs.HasOne(prop => prop.Magazine)
                    .WithMany(prop => prop.Subscriptions)
                    .HasForeignKey(prop => prop.MagazineId)
                    .IsRequired();

                subs.HasData(_magazines);
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
            });

            modelBuilder.Entity<Magazine>(mgzn =>
            {
                mgzn.HasMany(prop => prop.Subscriptions)
                    .WithOne(prop => prop.Magazine)
                    .HasForeignKey(prop => prop.MagazineId)
                    .IsRequired();

                mgzn.HasData(_magazines);
            });

            modelBuilder.Entity<Publication>(mgzn =>
            {
                mgzn.HasOne(prop => prop.Country)
                    .WithMany(prop => prop.Publications)
                    .HasForeignKey(prop => prop.CountryId)
                    .IsRequired();

                mgzn.HasData(_publications);
            });
        }
    }
}
