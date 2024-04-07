using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class ClienteRepository : ICliente
    {
        private readonly ClassDbContext _context;

        public async Task<object> Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }

        public Task<List<Cliente>> Atualizar(Cliente pedido)
        {
            throw new NotImplementedException();
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
