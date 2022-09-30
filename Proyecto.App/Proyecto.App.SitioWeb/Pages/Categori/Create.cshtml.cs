using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWeb.Pages.Categori
{
    public class CreateModel : PageModel
    {
        private IRepositorioCategoria _repoCategoria { get; set; }
        [BindProperty]
        public Categoria categoria { get; set; }
        public CreateModel()
        {
            _repoCategoria = new RepositorioCategoria(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repoCategoria.Agregar(categoria);
                return RedirectToPage("/Categori/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
