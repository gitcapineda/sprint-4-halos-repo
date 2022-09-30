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
    public class DeleteModel : PageModel
    {
        private IRepositorioFase _repoFase { get; set; }
        [BindProperty]
        public Fase fase { get; set; }
        public string respuesta { get; set; }
        public DeleteModel()
        {
            _repoFase = new RepositorioFase(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet(int id)
        {
            fase = _repoFase.BuscarPorId(id);
        }
        public void OnPost()
        {
            respuesta = _repoFase.Eliminar(fase.faseId);
            //return RedirectToPage("/Fas/List");
        }
    }
}
