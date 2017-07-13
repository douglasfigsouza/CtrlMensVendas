using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CtrlMensVendas.Models;

namespace CtrlMensVendas.Controllers
{
    public class ClientesController : Controller
    {
        private ClientesRepository clientesRep;
        public ClientesController()
        {
            this.clientesRep = new ClientesRepository();
        }
        // GET: Clientes
        public ActionResult addClientes()
        {
            return View();
        }

        //cadastra o clientes
        [HttpPost]
        public ActionResult addClientes(CLIENTES cliente)
        {
            clientesRep.addClientes(cliente);
            return View();
        }

       
    }
}