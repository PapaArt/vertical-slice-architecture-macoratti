using FluentResults;
using MediatR;

namespace Vertical_Slice_Architecture.Features.Produto.Queries
{
    public record GetProdutosQuery : IRequest<Result<List<Vertical_Slice_Architecture.Domain.Produto>>>;

    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, Result<List<Vertical_Slice_Architecture.Domain.Produto>>>
    {
        private readonly ProdutoRepository _repository;

        public GetProdutosQueryHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Vertical_Slice_Architecture.Domain.Produto>>> Handle(GetProdutosQuery command, CancellationToken cancellationToken)
        {
            var produtos = await _repository.GetAllAsync();
            return Result.Ok(produtos);
        }
    }
}
