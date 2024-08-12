using ACME.Domain.Contracts;
using ACME.Domain.Models.Entities;
using ACME.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACME.Infrastructure.Database.Repositories
{
    public class PrintDistributorRepository : BaseRepository<PrintDistributor>, IPrintDistributorRepository
    {
        public PrintDistributorRepository(ACMEDbContext context) : base(context) { }

        public async Task<IEnumerable<PrintDistributor>> GetPrintDistributorsFullInformationAsync(CancellationToken token)
        {
            var distributors = await GetAll()
                                        .Include(tbl => tbl.Publication)
                                        .ToListAsync(token);

            return distributors;
        }

        public async Task<IEnumerable<PrintDistributor>> GetPrintDistributorsFullInformationAsync(Expression<Func<PrintDistributor, bool>> expression, CancellationToken token)
        {
            var distributors = await GetByExpression(expression)
                                        .Include(tbl => tbl.Publication)
                                        .ToListAsync(token);

            return distributors;
        }
    }
}
