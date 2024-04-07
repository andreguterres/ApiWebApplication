using WebApi.Entities;

namespace WebApi.Repository
{
    public interface ICliente
    {
        Task<object> Adicionar(Cliente pedido);
        Task<List<Cliente>> Pesquisar();        
        Task<List<Cliente>> PesquisarPorId(int id);
        Task<List<Cliente>> Deletar(int id);
        Task<List<Cliente>> Atualizar(Cliente pedido);
    }
}
