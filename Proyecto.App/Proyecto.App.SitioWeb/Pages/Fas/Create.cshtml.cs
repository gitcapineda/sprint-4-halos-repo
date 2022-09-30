using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWeb.Pages.Fas
{
    public class CreateModel : PageModel
    {
        private IRepositorioFase _repoFase { get; set; }
        [BindProperty]
        public Fase fase { get; set; }
        public CreateModel()
        {
            _repoFase = new RepositorioFase(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Fase fase)
        {
            if (ModelState.IsValid)
            {
                _repoFase.Agregar(fase);
                return RedirectToPage("/Fas/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
