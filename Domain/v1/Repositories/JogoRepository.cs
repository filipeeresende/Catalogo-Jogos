using Domain.v1.Dto.InputModel;
using Domain.v1.Dto.ViewModel;
using Domain.v1.Interfaces.Repositories;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;

namespace Domain.v1.Repositories
{
    public class JogoRepository : IJogoRepository

    {
        private readonly JOGO_CATALOGDbContext _context;

        public JogoRepository(JOGO_CATALOGDbContext context)
        {
            _context = context;
        }

        public async Task<List<JogoViewModel>> Obter()
        {
            return await _context.Jogos
                .Select(x => new JogoViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Produtora = x.Produtora,
                }).ToListAsync();
        }

        public async Task<Jogo> ObterId(int id)
        {
            return await _context.Jogos
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> VerificarSeJogoExiste(string nome, string produtora)
        {
            return await _context.Jogos
                .Where(x => x.Nome == nome)
                .Where(x => x.Produtora == produtora)
                .AnyAsync();
        }

        public async Task Inserir(Jogo jogo)
        {
            await _context.AddAsync(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Jogo jogo)
        {
            _context.Update(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverJogo(Jogo jogo)
        {
            _context.Remove(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
