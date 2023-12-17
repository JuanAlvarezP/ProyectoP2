using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class CitasClase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la cita son obligatorias.")]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio.")]
        [StringLength(100, ErrorMessage = "El motivo no puede exceder los 100 caracteres.")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "El nombre del animal es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del animal no puede exceder los 50 caracteres.")]
        public string NombreAnimal { get; set; }

        [Required(ErrorMessage = "El nombre del propietario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del propietario no puede exceder los 50 caracteres.")]
        public string NombrePropietario { get; set; }

        [Required(ErrorMessage = "El número de teléfono del propietario es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        public string NumeroTelefonoPropietario { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string Observaciones { get; set; }
    }
}
