using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using WebApi.Dto;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clientes;
        private readonly IMapper _mapper;


        public ClienteController(ICliente clienteRepositorio)
        {
            _clientes = clienteRepositorio;
            //_mapper = mapper;

        }

        //[Route("Adicionar")]
        [HttpPost("/api/Adicionar")]
        public async Task<ActionResult<List<Cliente>>> Adicionar(Cliente cliente)
        {           

            await _clientes.Adicionar(cliente);

            return Ok("Cliente criado com sucesso!");

        }

        [HttpGet("/api/Pesquisar")]

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
        [HttpDelete("/api/Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clientes.Deletar(id);

            return Ok("Cliente Foi deletado!");
        }

        [HttpPut("/api/Atualizar")]
        public async Task<ActionResult> Atualizar(Cliente cliente)
        {

            await _clientes.Atualizar(cliente);

            return Ok("Foi Atualizado!");
        }
    }
}
