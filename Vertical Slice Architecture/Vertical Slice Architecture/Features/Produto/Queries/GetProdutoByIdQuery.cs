using FluentResults;
using MediatR;

namespace Vertical_Slice_Architecture.Features.Produto.Queries
{
    public record GetProdutoByIdQuery(Guid Id) : IRequest<Result<Vertical_Slice_Architecture.Domain.Produto>>;

    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Result<Vertical_Slice_Architecture.Domain.Produto>>
    {
        private readonly ProdutoRepository _repository;

        public GetProdutoByIdQueryHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Vertical_Slice_Architecture.Domain.Produto>> Handle(GetProdutoByIdQuery command, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(command.Id);

            if (produto is null)
                return Result.Fail("Produto não encontrado");

            return Result.Ok(produto);
        }
    }
}
