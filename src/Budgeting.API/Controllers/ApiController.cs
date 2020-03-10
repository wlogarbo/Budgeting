using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Budgeting.API.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        public IMediator Mediator { get; private set; }
        public ApiController(IMediator mediator) => Mediator = mediator;
    }
}
