using System.Collections.Generic;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public interface IRepositorioCategoria
    {
        Categoria Agregar(Categoria categoriaNueva); //metodos
        Categoria Modificar(Categoria categoriaActualizar);
        string Eliminar(int idEliminar);
        Categoria BuscarPorId(int idBuscar);
        IEnumerable<Categoria> BuscarTodos();
    }
}