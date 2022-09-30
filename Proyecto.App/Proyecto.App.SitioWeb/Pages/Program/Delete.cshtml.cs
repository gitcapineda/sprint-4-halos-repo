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
    public class DeleteModel : PageModel
    {
        private IRepositorioPrograma _repoPrograma { get; set; }
        [BindProperty]
        public Programa programa { get; set; }
        public DeleteModel()
        {
            _repoPrograma = new RepositorioPrograma(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet(int id)
        {
            programa = _repoPrograma.BuscarPorId(id);
        }
        public IActionResult OnPost()
        {
            _repoPrograma.Eliminar(programa.programaId);
            return RedirectToPage("/Program/List");
        }
    }
}