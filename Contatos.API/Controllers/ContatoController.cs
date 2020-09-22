using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Contatos.Application.Commom;
using Contatos.Application.Handlers;
using Contatos.Application.Requests;
using Contatos.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contatos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(ILogger<ContatoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("obter")]
        public async Task<ActionResult> Obter([FromServices] ObterContatoHandler handler, [FromQuery] long id)
        {
            try
            {
                var result = await handler.Handle(new ObterContatoRequest<HandlerResponse<Contato>>(id), new CancellationToken());
                if (result.Sucesso)
                {
                    return Ok(result.Resultado);
                }
                else
                {
                    return BadRequest(result.Mensagens);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, null);
                throw;
            }
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult> Listar([FromServices] ListarContatoHandler handler)
        {
            try
            {
                var result = await handler.Handle(new ListarContratoRequest<HandlerResponse<List<Contato>>>(), new CancellationToken());
                if (result.Sucesso)
                {
                    return Ok(result.Resultado);
                }
                else
                {
                    return BadRequest(result.Mensagens);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, null);
                throw;
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public async Task<ActionResult> Excluir([FromServices] ExcluirContatoHandler handler, [FromBody] long id)
        {
            try
            {
                var result = await handler.Handle(new ExcluirContatoRequest<HandlerResponse<Contato>>(id), new CancellationToken());
                if (result.Sucesso)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Mensagens);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, null);
                throw;
            }
        }

        [HttpPost]
        [Route("criar")]
        public async Task<ActionResult> Criar([FromServices] CriarContatoHandler handler, [FromBody] Contato contato)
        {
            try
            {
                var result = await handler.Handle(new CriarContatoRequest<HandlerResponse<Contato>>(contato), new CancellationToken());
                if (result.Sucesso)
                {
                    return Ok(result.Resultado);
                }
                else
                {
                    return BadRequest(result.Mensagens);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, null);
                throw;
            }
        }

        [HttpPost]
        [Route("alterar")]
        public async Task<ActionResult> Alterar([FromServices] AlterarContatoHandler handler, [FromBody] Contato contato)
        {
            try
            {
                var result = await handler.Handle(new AlterarContatoRequest<HandlerResponse<Contato>>(contato), new CancellationToken());
                if (result.Sucesso)
                {
                    return Ok(result.Resultado);
                }
                else
                {
                    return BadRequest(result.Mensagens);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, null);
                throw;
            }
        }
    }
}