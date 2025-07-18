using MediatR;
using Menu.Application.DTOs.Requests.FoodType;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Modules.FoodTypes.Commands.CreateFoodType;
using Menu.Application.Modules.FoodTypes.Commands.DeleteFoodType;
using Menu.Application.Modules.FoodTypes.Commands.UpdateFoodType;
using Menu.Application.Modules.FoodTypes.Queries.GetAllFoodType;
using Menu.Application.Modules.FoodTypes.Queries.GetFoodTypeById;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class FoodTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get: api/FoodTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTypeResponse>>> GetAll
            (CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllFoodTypesQuery(), token);
            return Ok(result);
        }

        // Get: api/FoodTypes/ {id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FoodTypeResponse>> GetById
            (Guid id, CancellationToken token)
        {
            var result = await _mediator.Send(new GetFoodTypeByIdQuery(id), token);
            return Ok(result);
        }

        // Post: api/FoodTypes
        [HttpPost]
        public async Task<ActionResult<FoodTypeResponse>> Create
            ([FromBody] CreateFoodTypeRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(new CreateFoodTypeCommand(request), token);
            return CreatedAtAction(nameof(GetById), new { id = result.IdFoodType }, result);
        }

        // Put: api/FoodTypes/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FoodTypeResponse>> Update
            (Guid id, [FromBody] UpdateFoodTypeRequest request, CancellationToken token)
        {
            var cmd = new UpdateFoodTypeCommand(request with { IdFoodType = id });
            var result = await _mediator.Send(cmd, token);
            return Ok(result);
        }

        // Delete: api/FoodTypes/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteFoodTypeCommand(id), token);
            return result ? NoContent() : NotFound();
        }
    }
}