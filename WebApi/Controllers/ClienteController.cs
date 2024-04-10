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


        public ClienteController(ICliente clienteRepositorio, IMapper mapper)
        {
            _clientes = clienteRepositorio;
            _mapper = mapper;

        }

        //[Route("Adicionar")]
        [HttpPost("Adicionar")]
        public async Task<ActionResult<List<Cliente>>> Adicionar([FromForm] Cliente cliente)
        {
            //var cliente = _mapper.Map<Cliente>(clienteDto);


            using (var memoryStream = new MemoryStream())
            {
                await cliente.LogoTipoFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                //if (memoryStream.Length < 2097152)
                //{
                    //var file = new ClienteDto()
                    //{
                    cliente.LogoTipo = memoryStream.ToArray();


                    //};

                    await _clientes.Adicionar(cliente);

                //}
                //else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }


            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //var filePath = Path.Combine(".\\Storage\\", cliente.LogoTipoFile.Name);

            //using Stream fileStream = new FileStream(filePath, FileMode.Create);
            ////var bytes = fileStream.Length;

            //cliente.LogoTipoFile.CopyTo(fileStream);


            //var clientes = new Cliente(cliente.Nome, cliente.Email, filePath, cliente.Logradouros);

            ////Nome, e-mail, Logotipo* e Logradouro    

            //await _clientes.Adicionar(clientes);

            return Ok("Cliente criado com sucesso!");

        }

        [HttpGet("/api/Pesquisar")]

        public async Task<ActionResult<IEnumerable<Cliente>>> Pesquisar()
        {
            List<Cliente> pedido = await _clientes.Pesquisar();

            return Ok(pedido);

        }

        [HttpGet("/api/PesquisarId/{id}")]
        public async Task<ActionResult<List<Cliente>>> PesquisarId(int id)
        {
            List<Cliente> pedido = await _clientes.PesquisarPorId(id);

            return Ok(pedido);

        }
        [HttpDelete("/Delete/{id}")]
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
