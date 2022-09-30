using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq; //conexion base de datos

namespace Proyecto.App.Persistencia
{
    public class RepositorioFase : IRepositorioFase
    {
        private readonly AppContext _appContext;
        public RepositorioFase(AppContext contexto)
        {
            _appContext = contexto;
        }

        Fase IRepositorioFase.Agregar(Fase faseNuevo)
        {
            var faseAgregar = _appContext.Fases.Add(faseNuevo);
            _appContext.SaveChanges();
            return faseAgregar.Entity;
        }

        Fase IRepositorioFase.Modificar(Fase faseActualizar)
        {
            var faseUpdate = _appContext.Fases.FirstOrDefault(c => c.faseId == faseActualizar.faseId);
            if (faseUpdate != null)
            {
                faseUpdate.fechaCambio = faseActualizar.fechaCambio;
                faseUpdate.nombreFase = faseActualizar.nombreFase;
                faseUpdate.descripcion = faseActualizar.descripcion;
                faseUpdate.estado = faseActualizar.estado;
                _appContext.SaveChanges();
            }
            return faseUpdate;
        }

        string IRepositorioFase.Eliminar(int idEliminar)
        {
            var faseBorrar = _appContext.Fases.FirstOrDefault(c => c.faseId == idEliminar);
            if (faseBorrar != null)
            {
                try
                {
                    _appContext.Fases.Remove(faseBorrar);
                    _appContext.SaveChanges();

                }
                catch (Exception e)
                {
                    return "No se puede eliminar esta fase porque tiene proyectos asociados";
                }
            }
            return "Eliminado correctamente";
        }

        Fase IRepositorioFase.BuscarPorId(int idBuscar)
        {
            return _appContext.Fases.FirstOrDefault(c => c.faseId == idBuscar);
        }

        IEnumerable<Fase> IRepositorioFase.BuscarTodos()
        {
            return _appContext.Fases;
        }
    }
}