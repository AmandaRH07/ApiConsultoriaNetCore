using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;
using Consultoria.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System;
using System.Threading.Tasks;


namespace Consultoria.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClientesController> logger;

        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            this.clienteManager = clienteManager;
            this.logger = logger;
        }

        // Documentação da API via Swagger para deixar mais claro o que está sendo produzido

        /// <summary>
        ///  Retorna todos os clientes cadastrados na base
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("Erro de teste");
            return Ok(await clienteManager.GetClientesAsync());
        }

        /// <summary>
        /// Retorna cliente consultado  pelo id
        /// </summary>
        /// <param name="id" example="123">Id do cliente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteAsync(id));
        }

        /// <summary>
        /// Insere novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            logger.LogInformation("Objeto recebido {@novoClienet}", novoCliente);

            Cliente clienteInserido;

            using(Operation.Time("Tempo de adição de um novo cliente"))
            {
                logger.LogInformation("Foi requisitada a inserção de um novo cliente");
                clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            }

            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
            logger.LogInformation("Fim da requisição");
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraCliente cliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(cliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id" example="123"></param>
        /// <remarks>Ao excluir um cliente, o mesmo será excluido permanentemente da base</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
