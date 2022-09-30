using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq; //conexion base de datos

namespace Proyecto.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;
        public RepositorioCliente(AppContext contexto)
        {
            _appContext = contexto;
        }

        Cliente IRepositorioCliente.Agregar(Cliente clienteNuevo)
        {
            var clienteAgregar = _appContext.Clientes.Add(clienteNuevo);
            _appContext.SaveChanges();
            return clienteAgregar.Entity;
        }

        Cliente IRepositorioCliente.Modificar(Cliente clienteActualizar)
        {
            var clienteUpdate = _appContext.Clientes.FirstOrDefault(c => c.clienteId == clienteActualizar.clienteId);
            if (clienteUpdate != null)
            {
                clienteUpdate.nombre = clienteActualizar.nombre;
                clienteUpdate.apellido = clienteActualizar.apellido;
                clienteUpdate.numDocumento = clienteActualizar.numDocumento;
                clienteUpdate.numTelefono = clienteActualizar.numTelefono;
                clienteUpdate.email = clienteActualizar.email;
                clienteUpdate.direccion = clienteActualizar.direccion;
                clienteUpdate.nacionalidad = clienteActualizar.nacionalidad;
                clienteUpdate.estado = clienteActualizar.estado;
                _appContext.SaveChanges();
            }
            return clienteUpdate;
        }

        string IRepositorioCliente.Eliminar(int idEliminar)
        {
            var clienteBorrar = _appContext.Clientes.FirstOrDefault(c => c.clienteId == idEliminar);
            if (clienteBorrar != null)
            {
                try
                {
                    _appContext.Clientes.Remove(clienteBorrar);
                    _appContext.SaveChanges();
                }
                catch(Exception e)
                {
                    return "No se puede eliminar este cliente porque tiene proyectos asociados";

                }

            }
            return "Eliminado correctamente";
        }

        Cliente IRepositorioCliente.BuscarPorId(int idBuscar)
        {
            return _appContext.Clientes.FirstOrDefault(c => c.clienteId == idBuscar);
        }

        IEnumerable<Cliente> IRepositorioCliente.BuscarTodos()
        {
            return _appContext.Clientes;
        }
    }
}