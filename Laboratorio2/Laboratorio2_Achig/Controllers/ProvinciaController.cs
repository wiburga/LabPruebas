using Laboratorio2.Data;
using Laboratorio2.Models; // Asegúrate de importar el espacio de nombres correcto
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio2.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly ProvinciaSqlDataAccessLayer _provinciaDataAccessLayer = new ProvinciaSqlDataAccessLayer();
        private readonly ClienteSqlDataAccessLayer _clienteDataAccessLayer = new ClienteSqlDataAccessLayer();

        public IActionResult Index()
        {
            var provincias = _provinciaDataAccessLayer.GetAllProvincias();
            ViewBag.Provincias = provincias;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int provinciaCodigo)
        {
            var clientes = _clienteDataAccessLayer.GetClientesPorProvincia(provinciaCodigo);
            ViewBag.Provincias = _provinciaDataAccessLayer.GetAllProvincias(); // Reobtenemos provincias para la vista
            ViewBag.Cedulas = clientes;
            return View();
        }
    }
}
