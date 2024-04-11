using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RazorWeb.Interfaces;
using RazorWeb.Models;

namespace RazorWeb.Controllers
{
    public class ClientesController : Controller

    {
        private readonly ICliente _icliente;
        public ClientesController(ICliente icliente)
        {
            _icliente = icliente;
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            return View(_icliente.Pesquisar());
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View(_icliente.PesquisarPorId(id));
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public ActionResult Create(Cliente collection)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    collection.LogoTipoFile.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    //if (memoryStream.Length < 2097152)
                    //{
                    //var file = new ClienteDto()
                    //{
                    collection.LogoTipo = memoryStream.ToArray();


                    //};

                    _icliente.Adicionar(collection);

                    //}
                    //else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_icliente.PesquisarPorId(id));
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente collection)
        {
            try
            {
                _icliente.Atualizar(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_icliente.PesquisarPorId(id));
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente collection)
        {
            try
            {
                _icliente.Deletar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Criar(Logradouro collection)
        {
            try
            {
                //_icliente.Adicionar(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
