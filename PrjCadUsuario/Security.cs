using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PrjCadUsuario
{
    public class Security
    {
        public String GeraSenhaAleatoria() {

            const string CAIXA_BAIXA = "abcdefghijklmnopqrstuvwxyz";
            const string CAIXA_ALTA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            const string NUMEROS = "0123456789";
            const string ESPECIAIS = @"~!@#$%^&*():;[]{}<>,.?/\|";
            string carac = CAIXA_ALTA.ToString() + CAIXA_BAIXA.ToString() + NUMEROS.ToString() + ESPECIAIS.ToString();

            // converte em uma matriz de caracteres
            char[] letras = carac.ToCharArray();

            // vamos embaralhar 5 vezes
            Embaralhar(ref letras, 5);

            // junta as partes e forma uma senha de 8 dígitos e/ou
            // caracteres
            string senha = new String(letras).Substring(0, 8);

            // exibe o resultado
            return senha;
        }

        static void Embaralhar(ref char[] array, int vezes)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= vezes; i++)
            {
                for (int x = 1; x <= array.Length; x++)
                {
                    Trocar(ref array[rand.Next(0, array.Length)],
                      ref array[rand.Next(0, array.Length)]);
                }
            }
        }

        static void Trocar(ref char arg1, ref char arg2)
        {
            char strTemp = arg1;
            arg1 = arg2;
            arg2 = strTemp;
        }
    }
}
