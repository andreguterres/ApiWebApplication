using RazorWeb.Models;

namespace RazorWeb.Interfaces
{
    public interface ICliente
    {
        Cliente Adicionar(Cliente cliente);
        List<Cliente> Atualizar(Cliente cliente);
        List<Cliente> Pesquisar();
        List<Cliente> PesquisarPorId(int id);
        Cliente Deletar(int id);
    }
}
