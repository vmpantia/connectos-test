using ACME.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsFullInformation(CancellationToken token);
        Task<IEnumerable<Subscription>> GetSubscriptionsFullInformation(Expression<Func<Subscription, bool>> expression, CancellationToken token);
    }
}