using ACME.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface IPrintDistributorRepository
    {
        Task<IEnumerable<PrintDistributor>> GetPrintDistributorsFullInformationAsync(CancellationToken token);
        Task<IEnumerable<PrintDistributor>> GetPrintDistributorsFullInformationAsync(Expression<Func<PrintDistributor, bool>> expression, CancellationToken token);
    }
}