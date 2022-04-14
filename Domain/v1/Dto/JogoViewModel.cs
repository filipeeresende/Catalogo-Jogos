using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.v1.Dto.ViewModel
{
    public class JogoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}



