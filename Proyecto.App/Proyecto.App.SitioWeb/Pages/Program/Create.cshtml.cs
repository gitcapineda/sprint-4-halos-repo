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
    public class CreateModel : PageModel
    {
        private IRepositorioPrograma _repoPrograma { get; set; }
        [BindProperty]
        public Programa programa { get; set; }
        public CreateModel()
        {
            _repoPrograma = new RepositorioPrograma(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Programa programa)
        {
            _repoPrograma.Agregar(programa);
            return RedirectToPage("/Program/List");
        }
    }
}
