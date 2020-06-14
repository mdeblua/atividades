using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new Application.Activities.List.Query(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await _mediator.Send(new Application.Activities.Details.Query { Id = id });
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Unit>> Create([FromBody] Application.Activities.Create.Command command)
        {
            return await _mediator.Send(command);
        }

    }
}