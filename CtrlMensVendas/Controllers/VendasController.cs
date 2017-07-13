using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CtrlMensVendas.Models;

namespace CtrlMensVendas.Controllers
{ 
    public class VendasController : Controller
    {
        testeController testectrl = new testeController();
        // GET: Vendas
        public ActionResult addVendas()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<CLIENTES> getClientes()
        {
            return testectrl.getAllClientes();
        }
    }
}