using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq; //conexion base de datos

namespace Proyecto.App.Persistencia
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly AppContext _appContext;
        public RepositorioCategoria(AppContext contexto)
        {
            _appContext = contexto;
        }

        Categoria IRepositorioCategoria.Agregar(Categoria categoriaNueva)
        {
            var categoriaAgregar = _appContext.Categorias.Add(categoriaNueva);
            _appContext.SaveChanges();
            return categoriaAgregar.Entity;
        }

        Categoria IRepositorioCategoria.Modificar(Categoria categoriaActualizar)
        {
            var categoriaUpdate = _appContext.Categorias.FirstOrDefault(c => c.categoriaId == categoriaActualizar.categoriaId);
            if (categoriaUpdate != null)
            {
                categoriaUpdate.nombreCategoria = categoriaActualizar.nombreCategoria;
                categoriaUpdate.descripcion = categoriaActualizar.descripcion;
                categoriaUpdate.estado = categoriaActualizar.estado;
                _appContext.SaveChanges();
            }
            return categoriaUpdate;
        }

        string IRepositorioCategoria.Eliminar(int idEliminar)
        {
            var categoriaBorrar = _appContext.Categorias.FirstOrDefault(c => c.categoriaId == idEliminar);
            if (categoriaBorrar != null)
            {
                try
                {
                    _appContext.Categorias.Remove(categoriaBorrar);
                    _appContext.SaveChanges();
                }
                catch(Exception e)
                {
                    return "No se puede eliminar esta categoria porque tiene proyectos asociados";
                }

            }
            return "Eliminado correctamente";
        }

        Categoria IRepositorioCategoria.BuscarPorId(int idBuscar)
        {
            return _appContext.Categorias.FirstOrDefault(c => c.categoriaId == idBuscar);
        }

        IEnumerable<Categoria> IRepositorioCategoria.BuscarTodos()
        {
            return _appContext.Categorias;
        }
    }
}