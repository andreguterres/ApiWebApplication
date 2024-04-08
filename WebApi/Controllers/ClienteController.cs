using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Collections.Generic;
using System.IO;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clientes;
        //private readonly IMapper _mapper;


        public ClienteController(ICliente clienteRepositorio/*, IMapper mapper*/)
        {
            _clientes = clienteRepositorio;
            //_mapper = mapper;

        }

        //[HttpPost]
        //public async Task<ActionResult<List<Cliente>>> Adicionar([FromForm] Cliente cliente)
        //{
        //    var filePath = Path.Combine("Storage", cliente.Logotipo.FileName);

        //    using Stream fileStream = new FileStream(filePath, FileMode.Create);
        //    cliente.Logotipo.CopyTo(fileStream);


        //    var clientes = new Cliente(cliente.Nome, cliente.Email, fileStream, cliente.Logradouros);

        //    //Nome, e-mail, Logotipo* e Logradouro    

        //    await _clientes.Adicionar(clientes);

        //    return Ok("Cliente criado com sucesso!");

        //}

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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clientes.Deletar(id);

            return Ok("Cliente Foi deletado!");
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Cliente cliente)
        {

            await _clientes.Atualizar(cliente);

            return Ok("Foi Atualizado!");
        }
    }
}
