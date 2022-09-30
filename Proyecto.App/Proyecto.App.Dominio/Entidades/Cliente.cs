using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.App.Dominio
{
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string numDocumento { get; set; }
        public string numTelefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string nacionalidad { get; set; }
        public Estado estado { get; set; }

        //Lista de proyectos
        //public List<Programa> programas { get; set; }
    }
}