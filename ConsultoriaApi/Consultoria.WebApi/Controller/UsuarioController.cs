using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews.Usuario;
using Consultoria.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Consultoria.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager manager;

        public UsuarioController(IUsuarioManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioLogado = await manager.ValidaUsuarioEGeraTokenAsync(usuario);
            if (usuarioLogado != null)
                return Ok(usuarioLogado);

            return Unauthorized();
        }

        [Authorize(Roles = "Presidente, Lider")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string login = User.Identity.Name;
            var usuario = await manager.GetAsync(login);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoUsuario novoUsuario)
        {
            var usuarioInserido = await manager.InsertAsync(novoUsuario);
            return CreatedAtAction(nameof(Get), new { login = novoUsuario.Login }, usuarioInserido);
        }
    }
}
