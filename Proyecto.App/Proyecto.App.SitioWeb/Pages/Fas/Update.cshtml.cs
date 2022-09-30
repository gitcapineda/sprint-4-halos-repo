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
    public class UpdateModel : PageModel
    {
        private IRepositorioFase _repoFase { get; set; }
        [BindProperty]
        public Fase fase { get; set; }
        public UpdateModel()
        {
            _repoFase = new RepositorioFase(new Proyecto.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int id)
        {
            fase = _repoFase.BuscarPorId(id);
            if (fase == null)
            {
                return RedirectToPage("/Fas/List");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Fase fase)
        {
            _repoFase.Modificar(fase);
            return RedirectToPage("/Fas/List");
        }
    }
}
