using Domain.Exceptions;
using Domain.v1.Dto.InputModel;
using Domain.v1.Dto.ViewModel;
using Domain.v1.Interfaces.Repositories;
using Domain.v1.Interfaces.Services;
using Infrastructure.Entites;

namespace Domain.v1.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<IList<JogoViewModel>> Obter()
        {
            IList<JogoViewModel> jogos = await _jogoRepository.Obter();

            if (!jogos.Any())
                throw new JogoNaoCadastradoException();

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> ObterId(int id)
        {
            Jogo jogo = await _jogoRepository.ObterId(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            var jogos = new JogoViewModel
            {
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            return jogos;
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            bool jogoExiste = await _jogoRepository
                .VerificarSeJogoExiste(jogo.Nome, jogo.Produtora);

            if (jogoExiste)
                throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Atualizar(int id, int preco)
        {
            Jogo entidadeJogo = await _jogoRepository.ObterId(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(int id)
        {
            Jogo jogo = await _jogoRepository.ObterId(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.RemoverJogo(jogo);
        }
    }
}