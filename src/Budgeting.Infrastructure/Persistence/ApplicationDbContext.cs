using Budgeting.Application.Common.Interfaces;
using Budgeting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Budgeting.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public static readonly LoggerFactory _myLoggerFactory =
       new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<BudgetItem> BudgetItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }
    }
}
