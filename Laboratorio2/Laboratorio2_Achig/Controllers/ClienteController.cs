using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Laboratorio2.Models;
using Laboratorio2.Data;

namespace Laboratorio2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteSqlDataAccessLayer _objClienteDAL = new ClienteSqlDataAccessLayer();

        // GET: ClienteController
        public IActionResult Index()
        {
            List<ClienteSql> listClient = _objClienteDAL.GetAllClientes().ToList();
            return View(listClient);
        }

        // GET: ClienteController/Create
        public IActionResult Create()
        {
            return View(new ClienteSql()); // Pasar un solo objeto ClienteSql
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteSql objCliente)
        {
            if (ModelState.IsValid)
            {
                _objClienteDAL.AddCliente(objCliente);
                return RedirectToAction(nameof(Index));
            }
            return View(objCliente);
        }

        // GET: ClienteController/Edit/5
        public IActionResult Edit(int id)
        {
            ClienteSql cliente = _objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteSql objCliente)
        {
            if (id != objCliente.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _objClienteDAL.UpdateCliente(objCliente);
                }
                catch
                {
                    // Manejo de errores
                    return View(objCliente);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(objCliente);
        }

        // GET: ClienteController/Delete/5
        public IActionResult Delete(int id)
        {
            ClienteSql cliente = _objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _objClienteDAL.DeleteCliente(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ClienteController/Details/5
        public IActionResult Details(int id)
        {
            ClienteSql cliente = _objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
    }
}
