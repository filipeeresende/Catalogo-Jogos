using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ApiCatalogoJogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(1, 5);
            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }


        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromRoute] Guid idjogo)
        {
            var jogo = await _jogoService.Obter(idjogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }


        [HttpPost]
        public async Task<ActionResult<List<JogoViewModel>>> InsertGame([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("já existe um jogo com este nome para essa produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("não existe este jogo");
            }
        }

        [HttpPatch("{idjogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("não existe este jogo");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();

            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}