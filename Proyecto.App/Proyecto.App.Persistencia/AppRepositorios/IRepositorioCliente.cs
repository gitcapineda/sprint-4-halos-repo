using System.Collections.Generic;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public interface IRepositorioCliente
    {
        Cliente Agregar(Cliente clienteNuevo); //metodos
        Cliente Modificar(Cliente clienteActualizar);
        string Eliminar(int idEliminar);
        Cliente BuscarPorId(int idBuscar);
        IEnumerable<Cliente> BuscarTodos();
    }
}