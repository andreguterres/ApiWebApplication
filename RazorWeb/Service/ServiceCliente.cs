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

        public List<Cliente> Atualizar(Cliente cliente)
        {
            var clienteAtualizar = new List<Cliente>();

            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resposta = clientes.PutAsync("https://localhost:7156/api/Atualizar", content);
                    resposta.Wait();
                    //if (resposta.Result.IsSuccessStatusCode)
                    //{
                    //    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    //    clienteAtualizar = JsonConvert.DeserializeObject<Cliente[]>(retorno.Result).ToList();
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteAtualizar;
        }
        public  Cliente Adicionar(Cliente cliente)
        {
            //string uriApis = "https://localhost:7156";
            var clienteAdicionar = new Cliente();

            try
            { 
                using (var clientes = new HttpClient())
                {
                    string x = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(x, Encoding.UTF8, "application/json");
                    var resposta =  clientes.PostAsync("https://localhost:7156/api/Adicionar", content);
                    resposta.Wait();
                    //if (resposta.Result.IsSuccessStatusCode)
                    //{
                    //    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    //    clienteAdicionar = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteAdicionar;
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



        public Cliente Deletar(int id)
        {
            var clienteDeletar = new Cliente();
            clienteDeletar.ClienteId = id;


            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(id);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resposta = clientes.DeleteAsync($"https://localhost:7156/api/Delete?id={id}");
                    resposta.Wait();
                    //if (resposta.Result.IsSuccessStatusCode)
                    //{
                    //    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    //    clienteDeletar =   retorno;
                    //}
                }
            }
            catch (Exception  mensagem)
            {

               var m = mensagem;
            }

            return clienteDeletar;
        }

    

        public List<Cliente> PesquisarPorId(int id)
        {
            var clientePesquisarPorId = new List<Cliente>();
            //clientePesquisarPorId.ClienteId = id;

            try
            {
                using (var clientes = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(clientePesquisarPorId);
                    var content = new StringContent(json, Encoding.UTF8);
                    var resposta = clientes.GetStringAsync($"https://localhost:7156/api/PesquisarId?id={id}");
                    //var resposta = clientes.GetStringAsync(uriApi + "PesquisarId?id=3");

                    //resposta.Wait();
                  //  if (resposta.Result.IsSuccessStatusCode)
                    //{
                        clientePesquisarPorId = JsonConvert.DeserializeObject<Cliente[]>(resposta.Result).ToList();

                        //var retorno = resposta.Result.Content.ReadAsStringAsync();
                        //clientePesquisarPorId = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                   // }
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
