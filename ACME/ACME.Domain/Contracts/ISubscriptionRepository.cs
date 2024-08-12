using ACME.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsFullInformationAsync(CancellationToken token);
        Task<IEnumerable<Subscription>> GetSubscriptionsFullInformationAsync(Expression<Func<Subscription, bool>> expression, CancellationToken token);
    }
}