using Budgeting.Application.Features.BudgetItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budgeting.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class BudgetItemsController : ControllerBase //: ApiController
    {
        public BudgetItemsController(IMediator mediator) { } //: base(mediator) { }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBudgetItemCommand command)
        {
            return null;
            //return await Mediator.Send(command);
        }
    }
}