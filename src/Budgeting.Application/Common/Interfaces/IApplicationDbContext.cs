using Budgeting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BudgetItem> BudgetItems { get; set; }

        DbSet<TestItem> TestItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
