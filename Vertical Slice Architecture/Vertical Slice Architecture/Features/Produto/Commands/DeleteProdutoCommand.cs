using FluentResults;
using MediatR;

namespace Vertical_Slice_Architecture.Features.Produto.Commands
{
    public record DeleteProdutoCommand(Guid Id) : IRequest<Result>;

    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Result>
    {
        private readonly ProdutoRepository _produtoRepository;

        public DeleteProdutoCommandHandler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Result> Handle(DeleteProdutoCommand command, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(command.Id);

            if (produto is null)
                return Result.Fail("Produto não encontrado.");

            await _produtoRepository.DeleteAsync(produto);

            return Result.Ok();
        }
    }
}
