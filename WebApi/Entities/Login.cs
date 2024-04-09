using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Login
    {
        [Required(ErrorMessage ="O e-mail é obrigatorio")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatoria")]
        [DataType(DataType.Password)]
        public string? Passaword { get; set; }

        [Display(Name ="Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
