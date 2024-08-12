using ACME.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersFullInformation(CancellationToken token);
        Task<IEnumerable<Customer>> GetCustomersFullInformation(Expression<Func<Customer, bool>> expression, CancellationToken token);
    }
}