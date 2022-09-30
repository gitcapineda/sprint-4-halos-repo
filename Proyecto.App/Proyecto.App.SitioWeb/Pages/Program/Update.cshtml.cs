using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWeb.Pages.Program
{
    public class UpdateModel : PageModel
    {
        private IRepositorioPrograma _repoPrograma { get; set; }
        [BindProperty]
        public Programa programa { get; set; }
        public UpdateModel()
        {
            _repoPrograma = new RepositorioPrograma(new Proyecto.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int id)
        {
            programa = _repoPrograma.BuscarPorId(id);
            if (programa == null)
            {
                return RedirectToPage("/Program/List");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Programa programa)
        {
            _repoPrograma.Modificar(programa);
            return RedirectToPage("/Program/List");
        }
    }
}
