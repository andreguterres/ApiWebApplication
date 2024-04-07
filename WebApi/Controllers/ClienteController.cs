using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Cliente>>> Adicionar(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var pedidoDTO = _mapper.Map<Pedido>(pedido);

            await _clientes.Adicionar(cliente);

            return Ok("Cliente criado com sucesso!");

        }

        //[HttpGet]

        //public async Task<ActionResult<IEnumerable<Pedido>>> Pesquisar()
        //{
        //    List<Pedido> pedido = await _pedidos.Pesquisar();

        //    return Ok(pedido);

        //}
    }
}
