using System;

namespace AlocaGFT.Utils.Exceptions
{
    public class EntidadeNaoEncontradaException : Exception
    {
        public EntidadeNaoEncontradaException(string msg="Entidade não encontrada!") : base(msg)
        {

        }
        public EntidadeNaoEncontradaException(string msg, Exception inner) : base(msg, inner)
        {

        }
    }
}