using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Passaword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Password", ErrorMessage ="As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }
}
