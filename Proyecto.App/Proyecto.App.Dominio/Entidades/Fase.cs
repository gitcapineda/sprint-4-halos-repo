using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.App.Dominio
{
    public class Fase
    {
        [Key]
        public int faseId { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaCambio { get; set; }
        public string nombreFase { get; set; }
        public string descripcion { get; set; }
        public Estado estado { get; set; }

         //Lista de proyectos
        //public List<Programa> programas { get; set; }
    }
}