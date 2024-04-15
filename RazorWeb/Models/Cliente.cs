using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        public string? Email { get; set; }


        [NotMapped]
        public IFormFile? LogoTipoFile { get; set; }        
        public byte[]? LogoTipo { get; set; }
        public List <Logradouro>? Logradouros { get; set; } 
    }
}
