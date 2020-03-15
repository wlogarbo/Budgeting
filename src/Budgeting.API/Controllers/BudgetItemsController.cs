using Budgeting.Application.Features.BudgetItems;
using Budgeting.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budgeting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetItemsController : ApiController
    {
        public BudgetItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<BudgetItem>> Get()
        {
            return await Mediator.Send(new GetBudgetItemsQuery());
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateBudgetItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Unit>> Update(UpdateBudgetItemCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
