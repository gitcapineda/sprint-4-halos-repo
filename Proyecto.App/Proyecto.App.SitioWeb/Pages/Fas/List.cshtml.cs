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
    public class ListModel : PageModel
    {
        public IEnumerable<Fase> fases { get; set; }
        private IRepositorioFase _repoFase { get; set; }
         public ListModel()
        {
            _repoFase = new RepositorioFase(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            fases = _repoFase.BuscarTodos();
        }
    }
}