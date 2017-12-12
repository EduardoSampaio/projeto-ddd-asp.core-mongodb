using System;

namespace Controle.Imobilizado.Infra.Crosscutting
{
    public class DomainException : Exception
    {
        public DomainException() : base("Generic Domain Error")
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}