using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength
        (100,
        MinimumLength = 2,
        ErrorMessage = "o nome do jogo deve conter entre 2 á 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength
       (100,
       MinimumLength = 2,
       ErrorMessage = "o nome do produto deve conter entre 2 á 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range
        (1,
        1000,
        ErrorMessage = "O preço do produto de ser entre 1 real á 1000 reais")]
        public double Preco { get; set; }

    }
}