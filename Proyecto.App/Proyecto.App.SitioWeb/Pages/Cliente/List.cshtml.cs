using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.SitioWeb.App.Pages
{
    public class ListModel : PageModel
    {
        public IEnumerable<Cliente> clientes { get; set; }
        private IRepositorioCliente _repoCliente { get; set; }
        public ListModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            clientes = _repoCliente.BuscarTodos();
        }
    }
}
