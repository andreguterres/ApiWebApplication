using RazorWeb.Models;

namespace RazorWeb.Interfaces
{
    public interface ICliente
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        List<Cliente> Pesquisar();
        Cliente PesquisarPorId(int id);
        Cliente Deletar(int id);
    }
}
