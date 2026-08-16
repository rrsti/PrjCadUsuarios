using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjCadUsuario.Models
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Boolean Ativo { get; set; }
    }
}
