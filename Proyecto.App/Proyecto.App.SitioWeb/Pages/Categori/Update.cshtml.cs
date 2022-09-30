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
    public class UpdateModel : PageModel
    {
        private IRepositorioCategoria _repoCategoria { get; set; }
        [BindProperty]
        public Categoria categoria { get; set; }
        public UpdateModel()
        {
            _repoCategoria = new RepositorioCategoria(new Proyecto.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int id)
        {
            categoria = _repoCategoria.BuscarPorId(id);
            if (categoria == null)
            {
                return RedirectToPage("/Categori/List");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Categoria categoria)
        {
            _repoCategoria.Modificar(categoria);
            return RedirectToPage("/Categori/List");
        }
    }
}
