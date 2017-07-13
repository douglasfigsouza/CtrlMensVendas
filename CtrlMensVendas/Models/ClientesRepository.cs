using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CtrlMensVendas.Models
{
    public class ClientesRepository
    {
        private GesCtrlDb context;
        public ClientesRepository()
        {
            this.context = new GesCtrlDb();
        }
        public void addClientes(CLIENTES cliente)
        {
            context.CLIENTES.Add(cliente);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<CLIENTES> getAllClientes()
        {
            var consulta = context.CLIENTES.AsEnumerable();
            return consulta.ToList();
        }

    }
}