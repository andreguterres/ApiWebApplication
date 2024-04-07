using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class ClienteRepository : ICliente
    {
        private readonly ClassDbContext _context;

        public ClienteRepository(ClassDbContext context)
        {
            _context = context;
        }

        public async Task<object> Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<List<Cliente>> Atualizar(Cliente cliente)
        {
            var clientex = await _context.Clientes.Where(x => x.ClienteId == cliente.ClienteId).FirstOrDefaultAsync();

          
            clientex.Nome = cliente.Nome;
            clientex.Email = cliente.Email;
            clientex.Logotipo = cliente.Logotipo;
            cliente.Logradouros = cliente.Logradouros;
           
            _context.Clientes.Update(clientex);
            await _context.SaveChangesAsync();

            return new List<Cliente> { cliente };
        }

        public async Task<List<Cliente>> Deletar(int id)
        {
            var pedidoExluido = _context.Clientes.Include(i => i.Logradouros).Where(x => x.ClienteId == id).First();

            _context.Clientes.Remove(pedidoExluido);

            await _context.SaveChangesAsync();

            return await _context.Clientes.ToListAsync();
        }

        public async Task<List<Cliente>> Pesquisar()
        {
            return _context.Clientes.ToList();

        }
    }
}
