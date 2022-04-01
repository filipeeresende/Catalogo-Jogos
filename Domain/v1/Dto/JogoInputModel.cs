using System.ComponentModel.DataAnnotations;

namespace Domain.v1.Dto.InputModel
{
    public class JogoInputModel
    {
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}