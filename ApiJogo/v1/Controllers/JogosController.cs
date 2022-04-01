using Domain.Exceptions;
using Domain.v1.Dto.InputModel;
using Domain.v1.Dto.ViewModel;
using Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiJogo.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<JogoViewModel>>> Obter()
        {
            try 
            {
                IList<JogoViewModel> jogos = await _jogoService.Obter();
               
                return Ok(jogos);
            }
            catch (JogoNaoCadastradoException ex)
            { 
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JogoViewModel>> ObterId(int id)
        {
            try
            {
                JogoViewModel jogo = await _jogoService.ObterId(id);

                return Ok(jogo);
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InsertGame(JogoInputModel jogoInputModel)
        {
            try
            {
                JogoViewModel jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarJogo(int id, int preco)
        {
            try
            {
                await _jogoService.Atualizar(id, preco);

                return Ok("Jogo atualizado com sucesso.");
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarJogo(int id)
        {
            try
            {
                await _jogoService.Remover(id);

                return Ok("Jogo excluído com sucesso.");
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}