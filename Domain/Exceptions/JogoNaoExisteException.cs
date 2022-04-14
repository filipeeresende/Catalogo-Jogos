using System;

namespace Domain.Exceptions
{
    public class JogoNaoExisteException : Exception
    {
        public JogoNaoExisteException()
         : base("Não existe nenhum jogo cadastrado.")
        {

        }
    }
}