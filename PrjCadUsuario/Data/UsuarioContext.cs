using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrjCadUsuario.Models;

namespace PrjCadUsuario.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }
    }
}