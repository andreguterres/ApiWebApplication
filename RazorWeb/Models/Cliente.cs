using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        //[NotMapped]
        public IFormFile LogoTipoFile { get; set; }
        //public byte[]? LogoTipo { get; set; }
        public ICollection<Logradouro> Logradouros { get; set; }
    }
}
