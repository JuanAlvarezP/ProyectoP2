using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class ClientesClase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string NombreCli { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string ApellidoCli { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string CorreoElectronicoCli { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        public string NumeroTelefonoCli { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistroCli { get; set; }

        public string Direccion { get; set; }
    }
}
