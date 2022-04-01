using Domain.v1.Dto.InputModel;
using Domain.v1.Dto.ViewModel;
using Infrastructure.Entites;

namespace Domain.v1.Interfaces.Repositories
{
    public interface IJogoRepository 
    {
        Task<List<JogoViewModel>> Obter();

        Task<Jogo> ObterId(int id);

        Task<bool> VerificarSeJogoExiste(string nome, string produtora);

        Task Inserir(Jogo jogo);

        Task Atualizar(Jogo jogo);

        Task RemoverJogo(Jogo jogo);
    }
}