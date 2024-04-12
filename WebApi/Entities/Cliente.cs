using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebApi.Entities
{
    public class Cliente
    {

        //Nome, e-mail, Logotipo* e Logradouro
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        //[NotMapped]
        //public IFormFile LogoTipoFile { get; set; }
        public byte[]? LogoTipo { get; set; }
        public ICollection<Logradouro>? Logradouros { get; set; }


    }
}
