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
    public class CreateModel : PageModel
    {
        private IRepositorioCliente _repoCliente { get; set; }
        [BindProperty]
        public Cliente cliente { get; set; }
        public CreateModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repoCliente.Agregar(cliente);
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }
    }
}