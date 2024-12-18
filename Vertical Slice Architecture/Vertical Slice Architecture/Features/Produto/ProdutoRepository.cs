using Microsoft.EntityFrameworkCore;
using Vertical_Slice_Architecture.Infrastructure.Context;

namespace Vertical_Slice_Architecture.Features.Produto
{
    public class ProdutoRepository
    {
        private readonly ProdutoDbContext _context;

        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vertical_Slice_Architecture.Domain.Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Vertical_Slice_Architecture.Domain.Produto?> GetByIdAsync(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(Vertical_Slice_Architecture.Domain.Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vertical_Slice_Architecture.Domain.Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vertical_Slice_Architecture.Domain.Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
