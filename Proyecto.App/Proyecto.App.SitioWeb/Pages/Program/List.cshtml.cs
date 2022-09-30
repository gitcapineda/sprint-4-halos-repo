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
    public class ListModel : PageModel
    {
        public IEnumerable<Programa> programas { get; set; }
        private IRepositorioPrograma _repoPrograma { get; set; }
        public ListModel()
        {
            _repoPrograma = new RepositorioPrograma(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            programas = _repoPrograma.BuscarTodos();
        }
    }
}
