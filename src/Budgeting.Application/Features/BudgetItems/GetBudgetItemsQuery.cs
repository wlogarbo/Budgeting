using Budgeting.Application.Common.Interfaces;
using Budgeting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Features.BudgetItems
{
    public class GetBudgetItemsQuery : IRequest<IEnumerable<BudgetItem>>
    {
        public class GetBudgetItemsQueryHandler : IRequestHandler<GetBudgetItemsQuery, IEnumerable<BudgetItem>>
        {
            private readonly IApplicationDbContext _context;

            public GetBudgetItemsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<BudgetItem>> Handle(GetBudgetItemsQuery request, CancellationToken cancellationToken)
            {
                var budgetItems = await _context.BudgetItems.ToListAsync();
                return budgetItems;
            }
        }
    }
}
