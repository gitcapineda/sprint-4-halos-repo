using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.App.Dominio
{
    public class Categoria
    {
        [Key]
        public int categoriaId { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombreCategoria { get; set; }
        public string descripcion { get; set; }
        public Estado estado { get; set; }

         //Lista de proyectos
        //public List<Programa> programas { get; set; }
    }
}