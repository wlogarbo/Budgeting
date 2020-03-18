using Budgeting.Application.Common.Exceptions;
using Budgeting.Application.Common.Interfaces;
using Budgeting.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Features.BudgetItems
{
    public class DeleteBudgetItemCommand : IRequest
    {
        //TODO Add validation
        public int Id { get; set; }

        public class DeleteBudgetItemCommandHandler : IRequestHandler<DeleteBudgetItemCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteBudgetItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteBudgetItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.BudgetItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BudgetItem), request.Id);
                }

                _context.BudgetItems.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
