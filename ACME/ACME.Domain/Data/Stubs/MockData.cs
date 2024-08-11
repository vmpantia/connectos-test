using ACME.Domain.Models.Entities;
using ACME.Domain.Models.Enums;
using Bogus;

namespace ACME.Domain.Data.Stubs
{
    public class MockData
    {
        public static Faker<Country> MockCountry() =>
            new Faker<Country>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.Code, opt => opt.Address.CountryCode())
                .RuleFor(prop => prop.Name, opt => opt.Address.Country())
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());

        public static Faker<Magazine> MockMagazine() =>
            new Faker<Magazine>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.Code, opt => opt.Company.CompanySuffix())
                .RuleFor(prop => prop.Name, opt => opt.Company.CompanyName())
                .RuleFor(prop => prop.Description, opt => opt.Company.CatchPhrase())
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());

        public static Faker<Customer> MockCustomer() =>
            new Faker<Customer>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.FirstName, opt => opt.Person.FirstName)
                .RuleFor(prop => prop.LastName, opt => opt.Person.LastName)
                .RuleFor(prop => prop.Email, opt => opt.Person.Email)
                .RuleFor(prop => prop.Phone, opt => opt.Person.Phone)
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());

        public static Faker<Address> MockAddress(IEnumerable<Guid> customerIds, IEnumerable<Guid> countryIds) =>
            new Faker<Address>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.CustomerId, opt => opt.PickRandom(customerIds))
                .RuleFor(prop => prop.AddressLine1, opt => opt.Person.Address.Street)
                .RuleFor(prop => prop.City, opt => opt.Person.Address.City)
                .RuleFor(prop => prop.ZipCode, opt => opt.Person.Address.ZipCode)
                .RuleFor(prop => prop.State, opt => opt.Person.Address.State)
                .RuleFor(prop => prop.CountryId, opt => opt.PickRandom(countryIds))
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());

        public static Faker<Subscription> MockSubscription(Guid customerId, IEnumerable<Guid> customerAddressIds, IEnumerable<Guid> magazineIds) =>
            new Faker<Subscription>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.CustomerId, customerId)
                .RuleFor(prop => prop.AddressId, opt => opt.PickRandom(customerAddressIds))
                .RuleFor(prop => prop.MagazineId, opt => opt.PickRandom(magazineIds))
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());

        public static Faker<Publication> MockPublication(IEnumerable<Guid> countryIds) =>
            new Faker<Publication>()
                .RuleFor(prop => prop.Id, opt => opt.Random.Guid())
                .RuleFor(prop => prop.Name, opt => opt.Company.CompanyName())
                .RuleFor(prop => prop.CountryId, opt => opt.PickRandom(countryIds))
                .RuleFor(prop => prop.Status, opt => opt.PickRandom<Status>())
                .RuleFor(prop => prop.CreatedAtUtcNow, opt => opt.Date.PastOffset())
                .RuleFor(prop => prop.CreatedBy, opt => opt.Internet.Email());
    }
}
