using ACME.Domain.Contracts;
using ACME.Domain.Models.Entities;
using ACME.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACME.Infrastructure.Database.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ACMEDbContext context) : base(context) { }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsFullInformationAsync(CancellationToken token)
        {
            var subscriptions = await GetAll()
                                        .Include(tbl => tbl.Customer)
                                        .Include(tbl => tbl.Address)
                                        .Include(tbl => tbl.Magazine)
                                        .AsSplitQuery()
                                        .ToListAsync(token);

            return subscriptions;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsFullInformationAsync(Expression<Func<Subscription, bool>> expression, CancellationToken token)
        {
            var subscriptions = await GetByExpression(expression)
                                        .Include(tbl => tbl.Customer)
                                        .Include(tbl => tbl.Address)
                                        .Include(tbl => tbl.Magazine)
                                        .AsSplitQuery()
                                        .ToListAsync(token);

            return subscriptions;
        }
    }
}
