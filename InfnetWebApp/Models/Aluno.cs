using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InfnetWebApp.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "o nome deve ter pelo menos 6 caracteres")]
        [Required(ErrorMessage ="o nome é obrigatório")]
        [Display(Name ="Nome do aluno")]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       
        public DateTime DataNascimento { get; set; }
    }
}
