using Consultoria.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Data.Context
{
    public class ConsultoriaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ConsultoriaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}