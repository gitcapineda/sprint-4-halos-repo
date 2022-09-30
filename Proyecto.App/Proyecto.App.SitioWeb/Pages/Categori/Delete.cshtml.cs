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
    public class DeleteModel : PageModel
    {
        private IRepositorioCategoria _repoCategoria { get; set; }
        [BindProperty]
        public Categoria categoria { get; set; }
        public string respuesta { get; set; }
        public DeleteModel()
        {
            _repoCategoria = new RepositorioCategoria(new Proyecto.App.Persistencia.AppContext());
        }
        public void OnGet(int id)
        {
            categoria = _repoCategoria.BuscarPorId(id);
        }
        public void OnPost()
        {
            respuesta = _repoCategoria.Eliminar(categoria.categoriaId);
            //return RedirectToPage("/Categori/List");
        }
    }
}
