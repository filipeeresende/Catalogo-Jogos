using Domain.v1.Dto.InputModel;
using Domain.v1.Dto.ViewModel;

namespace Domain.v1.Interfaces.Services
{
    public interface IJogoService 
    {
        Task<IList<JogoViewModel>> Obter();
        Task<JogoViewModel> ObterId(int id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(int id, int preco);
        Task Remover(int id);
    }
}
