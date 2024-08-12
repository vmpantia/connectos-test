using ACME.Domain.Contracts;
using ACME.Domain.Models.Entities;
using ACME.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACME.Infrastructure.Database.Repositories
{
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(ACMEDbContext context) : base(context) { }

        public async Task<IEnumerable<Publication>> GetPublicationsFullInformationAsync(CancellationToken token)
        {
            var publications = await GetAll()
                                        .Include(tbl => tbl.Country)
                                        .Include(tbl => tbl.PrintDistributor)
                                        .AsSplitQuery()
                                        .ToListAsync(token);

            return publications;
        }

        public async Task<IEnumerable<Publication>> GetPublicationsFullInformationAsync(Expression<Func<Publication, bool>> expression, CancellationToken token)
        {
            var publications = await GetByExpression(expression)
                                        .Include(tbl => tbl.Country)
                                        .Include(tbl => tbl.PrintDistributor)
                                        .AsSplitQuery()
                                        .ToListAsync(token);

            return publications;
        }
    }
}
