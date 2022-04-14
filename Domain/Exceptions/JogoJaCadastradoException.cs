using System;

namespace Domain.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException()
         : base("Este jogo já está cadastrado.")
        {

        }
    }
}