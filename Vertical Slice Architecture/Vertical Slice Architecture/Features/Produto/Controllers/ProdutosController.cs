using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertical_Slice_Architecture.Features.Produto.Commands;
using Vertical_Slice_Architecture.Features.Produto.Queries;

namespace Vertical_Slice_Architecture.Features.Produto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProdutoCommand(id));
            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProdutoByIdQuery(id));
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProdutosQuery());
            return Ok(result.Value);
        }
    }
}
