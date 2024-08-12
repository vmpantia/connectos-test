using ACME.Domain.Contracts;
using ACME.Domain.Models.Entities;
using ACME.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACME.Infrastructure.Database.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ACMEDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetCustomersFullInformation(CancellationToken token)
        {
            var customers = await GetAll()
                                    .Include(tbl => tbl.Addresses)
                                    .Include(tbl => tbl.Subscriptions)
                                    .ToListAsync(token);

            return customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomersFullInformation(Expression<Func<Customer, bool>> expression, CancellationToken token)
        {
            var customers = await GetByExpression(expression)
                                    .Include(tbl => tbl.Addresses)
                                    .Include(tbl => tbl.Subscriptions)
                                    .ToListAsync(token);

            return customers;
        }
    }
}
