using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.App.Dominio
{
    public class Programa
    {
        [Key]
        public int programaId { get; set; }

        public int? clienteId { get; set; }
        public Cliente cliente { get; set; }
       
        public int? categoriaId { get; set; }
        public Categoria categoria { get; set; }

        public int? faseId { get; set; }
        public Fase fase { get; set; }

        public DateTime fechaRegistro { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string tiempoEstimado { get; set; }
        public DateTime fechaEjecucion { get; set; }
        public string costo { get; set; }
        public string descripcion { get; set; }
        public Estado estado { get; set; }
    } 
}