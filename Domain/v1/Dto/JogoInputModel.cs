using System.ComponentModel.DataAnnotations;

namespace Domain.v1.Dto.InputModel
{

    public class JogoInputModel
    {
        [Required(ErrorMessage = "O nome é obrigatorio.")]
        [StringLength(80,
        ErrorMessage = "O nome devera ter entre 3 á 80 caracteres",
        MinimumLength = 3)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "A produtora é obrigatorio.")]
        [StringLength(80,
        ErrorMessage = "A produtora devera ter entre 3 á 80 caracteres",
        MinimumLength = 3)]
        public string Produtora { get; set; } = null!;

        [Required(ErrorMessage = "O preço é obrigatorio.")]
        [Range(0, 999.99, ErrorMessage = "O preço devera variar entre 0 á 999.99.")]
        public double Preco { get; set; }

    }
}