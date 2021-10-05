using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews.Usuario;
using Consultoria.Manager.Interfaces.Manager;
using Consultoria.Manager.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consultoria.Manager.Implemantation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository repository;
        private readonly IMapper mapper;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            mapper = mapper;
        }


        public async Task<IEnumerable<UsuarioView>> GetAsync()
        {
            return mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await repository.GetAsync());
        }

        public async Task<UsuarioView> GetAsync(string login)
        {
            return mapper.Map<UsuarioView>(await repository.GetAsync(login));
        }

        public async Task<UsuarioView> InsertAsync(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            return mapper.Map<UsuarioView>(await repository.InsertAsync(usuario));
        }

        public async Task<UsuarioView> UpdateAsync(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            return mapper.Map<UsuarioView>(await repository.UpdateAsync(usuario));
        }

        public async Task<bool> ValidaSenhaAsync(Usuario usuario)
        {
            var usuarioConsultado = await repository.GetAsync(usuario.Login);
            if (usuarioConsultado == null)
            {
                return false;
            }

            return await ValidaEAtualizaHashAsync(usuario, usuarioConsultado.Senha);
        }

        private void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }

        private async Task<bool> ValidaEAtualizaHashAsync(Usuario usuario, string hash)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
