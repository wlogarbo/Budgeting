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
        //TODO Add validation
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public class CreateBudgetItemCommandHandler : IRequestHandler<CreateBudgetItemCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateBudgetItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBudgetItemCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.BudgetItem()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Amount = request.Amount,
                    Frequency = request.Frequency,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Type = request.Type
                };

                var ent = new TestItem()
                {
                    Name = request.Name,
                    Description = request.Description
                };

                _context.BudgetItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
