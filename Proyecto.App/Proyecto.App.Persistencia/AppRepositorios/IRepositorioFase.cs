using System.Collections.Generic;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public interface IRepositorioFase
    {
        Fase Agregar(Fase faseNuevo); //metodos
        Fase Modificar(Fase faseActualizar);
        string Eliminar(int idEliminar);
        Fase BuscarPorId(int idBuscar);
        IEnumerable<Fase> BuscarTodos();
    }
}