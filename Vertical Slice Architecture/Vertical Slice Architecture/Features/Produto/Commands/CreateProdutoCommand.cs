using FluentResults;
using MediatR;

namespace Vertical_Slice_Architecture.Features.Produto.Commands
{
    public record CreateProdutoCommand(string Nome, decimal Preco) : IRequest<Result<Guid>>;

    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Result<Guid>>
    {
        private readonly ProdutoRepository _repository;

        public CreateProdutoCommandHandler(ProdutoRepository produtoRepository)
        {
            _repository = produtoRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Vertical_Slice_Architecture.Domain.Produto(request.Nome, request.Preco);
            await _repository.AddAsync(produto);

            return Result.Ok(produto.Id);
        }
    }
}
