﻿using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(int id);

        Task<Cliente> GetClienteAsync(int id);

        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> InsertClienteAsync(NovoCliente cliente);

        Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);

    }
}