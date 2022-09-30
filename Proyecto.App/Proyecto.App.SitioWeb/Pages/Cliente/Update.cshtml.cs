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
    public class UpdateModel : PageModel
    {
        private IRepositorioCliente _repoCliente { get; set; }
        [BindProperty]
        public Cliente cliente { get; set; }
        public UpdateModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int id)
        {
            cliente = _repoCliente.BuscarPorId(id);
            if (cliente == null)
            {
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Cliente cliente)
        {
            _repoCliente.Modificar(cliente);
            return RedirectToPage("/Cliente/List");
        }
    }
}