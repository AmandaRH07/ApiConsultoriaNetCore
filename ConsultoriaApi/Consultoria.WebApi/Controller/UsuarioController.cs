using Consultoria.Core.Domain;
using Consultoria.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("ValidaUsuario")]
        public async Task<IActionResult> ValidaUsuario([FromBody] Usuario usuario)
        {
            var valido = await manager.ValidaSenhaAsync(usuario);
            if (valido)
                return Ok();

            return Unauthorized();
        }

        [HttpGet("{login}")]
        public string Get(string login)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            var usuarioInserido = await manager.InsertAsync(usuario);
            return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
        }
    }
}
