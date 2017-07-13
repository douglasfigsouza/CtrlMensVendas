using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CtrlMensVendas.Models;

namespace CtrlMensVendas.Controllers
{
    public class testeController : ApiController
    {
        ClientesRepository clienterep = new ClientesRepository();
        [HttpGet]
        public IEnumerable<CLIENTES> getAllClientes()
        {
            return clienterep.getAllClientes();
        }
    }
}
