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

        [NotMapped]
        public IFormFile LogoTipo { get; set; }
        public string Logotipo { get; set; }
        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();

        //public Cliente (string? nome, string? email, IFormFile logotipo, List<Logradouro> logradouros)
        //{
        //    Nome = nome;
        //    Email = email;
        //    Logotipo = logotipo;
        //    Logradouros = logradouros;
        //}
    }
}
