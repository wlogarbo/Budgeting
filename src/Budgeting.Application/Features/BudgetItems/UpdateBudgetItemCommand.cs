using Budgeting.Application.Common.Exceptions;
using Budgeting.Application.Common.Interfaces;
using Budgeting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Features.BudgetItems
{
    public class UpdateBudgetItemCommand : IRequest
    {
        //TODO Add validation
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public class UpdateBudgetItemCommandHandler : IRequestHandler<UpdateBudgetItemCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateBudgetItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateBudgetItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.BudgetItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BudgetItem), request.Id);
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Amount = request.Amount;
                entity.Frequency = request.Frequency;
                entity.StartDate = request.StartDate;
                entity.EndDate = request.EndDate;
                entity.Type = request.Type;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
