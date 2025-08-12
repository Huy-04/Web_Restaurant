using MediatR;
using Menu.Application.DTOs.Requests.Food;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Modules.Food.Commands.CreateFood;
using Menu.Application.Modules.Food.Commands.DeleteFood;
using Menu.Application.Modules.Food.Commands.UpdateFood;
using Menu.Application.Modules.Food.Queries.GetAllFoods;
using Menu.Application.Modules.Food.Queries.GetFoodById;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public sealed class FoodController : Controller
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get: api/Food
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodResponse>>> GetAll
            (CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllFoodsQuery(), token);
            return Ok(result);
        }

        // Get: api/Food/ {id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FoodResponse>> GetById
            ([FromRoute] Guid id, CancellationToken token)
        {
            var result = await _mediator.Send(new GetFoodByIdQuery(id), token);
            return Ok(result);
        }

        // Post: api/Food
        [HttpPost]
        public async Task<ActionResult<FoodResponse>> Create
            ([FromBody] CreateFoodRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(new CreateFoodCommand(request), token);
            return CreatedAtAction(nameof(GetById), new { id = result.IdFood }, result);
        }

        // Put: api/Food/ {id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FoodResponse>> Update
            ([FromRoute] Guid id, UpdateFoodRequest request, CancellationToken token)
        {
            //var cmd = new UpdateFoodCommand(id, request);
            var result = await _mediator.Send(new UpdateFoodCommand(id, request), token);
            return Ok(result);
        }

        // Delete: api/Food/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> Delete
            ([FromRoute] Guid id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteFoodCommand(id), token);
            return result ? NoContent() : NotFound();
        }
    }
}