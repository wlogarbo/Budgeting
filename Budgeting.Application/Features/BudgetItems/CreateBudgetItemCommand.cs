using Budgeting.Application.Common.Interfaces;
using Budgeting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Features.BudgetItems
{
    public class CreateBudgetItemCommand : IRequest<int>
    {
        public class CreateBudgetItemCommandHandler : IRequestHandler<CreateBudgetItemCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateBudgetItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBudgetItemCommand request, CancellationToken cancellationToken)
            {
                var entity = new BudgetItem()
                {
                    Name = "",
                    Description = "",
                    Amount = 0,
                    Frequency = "",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Type = ""
                };

                _context.BudgetItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
