using System.Collections.Generic;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public interface IRepositorioPrograma
    {
        Programa Agregar(Programa programaNuevo); //metodos
        Programa Modificar(Programa programaActualizar);
        void Eliminar(int idEliminar);
        Programa BuscarPorId(int idBuscar);
        IEnumerable<Programa> BuscarTodos();
    }
}