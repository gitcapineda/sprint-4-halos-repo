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
    public class DeleteModel : PageModel
    {
        private IRepositorioCliente _repoCliente { get; set; }
        [BindProperty]
        public Cliente cliente { get; set; }
        public string respuesta { get; set; }
        public DeleteModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet(int id)
        {
            cliente = _repoCliente.BuscarPorId(id);
        }
        public void OnPost()
        {
            respuesta = _repoCliente.Eliminar(cliente.clienteId);
            //Page.ClientScript.RegisterStartupScript(this.GetType(),"ErrorAlert","alert('Some text here - maybe ex.Message');",true);
            //return RedirectToPage("/Cliente/List");
        }
    }
}