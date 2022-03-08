using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(50, ErrorMessage = "O nome do livro não pode ter mais de 50 caracteres")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome do escritor é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(25, ErrorMessage = "O nome do escritor nao pode ter mais de 25 caracteres")]
        [Display(Name = "Nome do Escritor")]
        public string NomeEscritor { get; set; }

        [Required(ErrorMessage = "A sinopse é obrigatória", AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data da publicação")]
        public DateTime DataPublicacao { get; set; }
    }
}