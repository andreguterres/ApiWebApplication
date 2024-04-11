using Newtonsoft.Json;
using RazorWeb.Interfaces;
using RazorWeb.Models;
using System.Text;

//using System.Text.Json.Serialization;

namespace RazorWeb.Service
{
    public class ServiceCliente : ICliente
    {
        private readonly string uriApi = "https://localhost:7156/api/";
        public  Cliente Adicionar(Cliente cliente)
        {
            //string uriApis = "https://localhost:7156";
            var clienteAdicionar = new Cliente();

            try
            { 
                using (var clientes = new HttpClient())
                {
                    string x = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(x, Encoding.UTF8,"application/json");
                    var resposta =  clientes.PostAsJsonAsync(uriApi + "Adicionar",content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        clienteAdicionar = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteAdicionar;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            var clienteAtualizar = new Cliente();

            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resposta = clientes.PutAsync(uriApi + "Atualizar", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        clienteAtualizar = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteAtualizar;
        }

        public Cliente Deletar(int id)
        {
            var clienteDeletar = new Cliente();
            clienteDeletar.ClienteId = id;


            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(clienteDeletar.ClienteId);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resposta = clientes.DeleteAsync(uriApi + "Delete");
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        clienteDeletar = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteDeletar;
        }

        public List<Cliente> Pesquisar()
        {
            var retorno = new List<Cliente>();

            try
            {
                using (var clientes = new HttpClient())
                {
               
                    var resposta = clientes.GetStringAsync(uriApi + "Pesquisar");
                    resposta.Wait();

                    retorno = JsonConvert.DeserializeObject<Cliente[]>(resposta.Result).ToList();


                }
            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }

        public Cliente PesquisarPorId(int id)
        {
            var clientePesquisarPorId = new Cliente();
            clientePesquisarPorId.ClienteId = id;

            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(clientePesquisarPorId.ClienteId);
                    var content = new StringContent(json, Encoding.UTF8);
                    var resposta = clientes.GetAsync(uriApi + "PesquisarId");
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        clientePesquisarPorId = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clientePesquisarPorId;
        }
    }
}
