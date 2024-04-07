using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clientes;
        //private readonly IMapper _mapper;


        public ClienteController(ICliente clienteRepositorio/*, IMapper mapper*/)
        {
            _clientes = clienteRepositorio;
            //_mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> Adicionar(Cliente cliente/*, [FromForm] DocumentInfo foto*/)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //using( var stream = new FileStream(FileMode.Create, FileAccess.Write))
            //{

            //}

            await _clientes.Adicionar(cliente);

            return Ok("Cliente criado com sucesso!");

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Cliente>>> Pesquisar()
        {
            List<Cliente> pedido = await _clientes.Pesquisar();

            return Ok(pedido);

        }

        [HttpGet("/api/PesquisarId")]
        public async Task<ActionResult<List<Cliente>>> PesquisarId(int id)
        {
            List<Cliente> pedido = await _clientes.PesquisarPorId(id);

            return Ok(pedido);

        }
    }
}
