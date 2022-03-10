using System;

namespace ApiCatalogoJogos.Entites
{
    public class Jogo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}