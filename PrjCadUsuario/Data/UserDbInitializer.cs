using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrjCadUsuario.Models;

namespace PrjCadUsuario.Data
{
    public class UserDbInitializer
    {
        public static void Initialize(UsuarioContext context)
        {
            context.Database.EnsureCreated();
            if (context.Usuarios.Any())
            {
                return;
            }

            var usuarios = new Usuario[]
            {
                new Usuario {Nome="Administrador do Sistema",Login="admin",Email="rrsilva.mronline@gmail.com",Ativo=true, Senha = "admin", Telefone="(21)96937-0065"},
                new Usuario {Nome="Rômulo Ribeiro da Silva",Login="rribeiro",Email="rrsilva.mronline@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)96937-0065"},
                new Usuario {Nome="Aline Rosa",Login="arosa",Email="arsoa@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)91235-0065"},
                new Usuario {Nome="Caio Bernardo",Login="cbernardo",Email="cbernardo@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)91534-0065"},
                new Usuario {Nome="Edimo Araújo da Silva",Login="edaraujo",Email="edaraujo@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)99234-0065"},
                new Usuario {Nome="Lúcia Helena Ribeiro da Silva",Login="lhelena",Email="lhelena@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)99534-0065"},
                new Usuario {Nome="Victor Hugo",Login="vhugo",Email="vhugo@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)99634-0065"},
                new Usuario {Nome="Maria Socorro",Login="msocorro",Email="msocorro@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)99884-0065"},
                new Usuario {Nome="Sebastião Bernardo",Login="sbernardo",Email="sbernardo@gmail.com",Ativo=true, Senha = new Security().GeraSenhaAleatoria(), Telefone="(21)91234-1165"},
            };

            foreach (Usuario u in usuarios)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();
        }
    }
}
