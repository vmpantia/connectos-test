using ACME.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ACME.Domain.Contracts
{
    public interface IPublicationRepository : IBaseRepository<Publication>
    {
        Task<IEnumerable<Publication>> GetPublicationsFullInformationAsync(CancellationToken token);
        Task<IEnumerable<Publication>> GetPublicationsFullInformationAsync(Expression<Func<Publication, bool>> expression, CancellationToken token);
    }
}