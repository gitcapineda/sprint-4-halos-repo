using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq; //conexion base de datos

namespace Proyecto.App.Persistencia
{
    public class RepositorioPrograma : IRepositorioPrograma
    {
        private readonly AppContext _appContext;
        public RepositorioPrograma(AppContext contexto)
        {
            _appContext = contexto;
        }

        Programa IRepositorioPrograma.Agregar(Programa programaNuevo)
        {
            var programaAgregar = _appContext.Programas.Add(programaNuevo);
            _appContext.SaveChanges();
            return programaAgregar.Entity;
        }

        Programa IRepositorioPrograma.Modificar(Programa programaActualizar)
        {
            var programaUpdate = _appContext.Programas.FirstOrDefault(c => c.programaId == programaActualizar.programaId);
            if (programaUpdate != null)
            {
                programaUpdate.clienteId = programaActualizar.clienteId;
                programaUpdate.categoriaId = programaActualizar.categoriaId;
                programaUpdate.faseId = programaActualizar.faseId;
                programaUpdate.nombre = programaActualizar.nombre;
                programaUpdate.codigo = programaActualizar.codigo;
                programaUpdate. tiempoEstimado = programaActualizar.tiempoEstimado;
                programaUpdate.fechaEjecucion = programaActualizar.fechaEjecucion;
                programaUpdate.costo = programaActualizar.costo;
                programaUpdate.descripcion = programaActualizar.descripcion;
                programaUpdate.estado = programaActualizar.estado;
                _appContext.SaveChanges();
            }
            return programaUpdate;
        }

        void IRepositorioPrograma.Eliminar(int idEliminar)
        {
            var programaBorrar = _appContext.Programas.FirstOrDefault(c => c.programaId == idEliminar);
            if (programaBorrar != null)
            {
                _appContext.Programas.Remove(programaBorrar);
                _appContext.SaveChanges();
            }
        }

        Programa IRepositorioPrograma.BuscarPorId(int idBuscar)
        {
            return _appContext.Programas.FirstOrDefault(c => c.programaId == idBuscar);
        }

        IEnumerable<Programa> IRepositorioPrograma.BuscarTodos()
        {
            return _appContext.Programas;
        }
    }
}