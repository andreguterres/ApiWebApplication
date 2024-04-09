using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

namespace WebApi.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        [NotMapped]
        public IFormFile LogoTipoFile { get; set; }

        public string? Logotipo { get; set; }
        public List<LogradouroDto> Logradouros { get; set; } = new List<LogradouroDto>();
     
    }
}
