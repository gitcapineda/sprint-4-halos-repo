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
    public class ListModelC : PageModel
    {
        public IEnumerable<Categoria> categorias { get; set; }
        private IRepositorioCategoria _repoCategoria { get; set; }
        public ListModelC()
        {
            _repoCategoria = new RepositorioCategoria(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            categorias = _repoCategoria.BuscarTodos();
        }
    }
}
