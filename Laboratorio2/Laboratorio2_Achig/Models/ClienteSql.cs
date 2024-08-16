using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Models
{
    public class ClienteSql
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, ErrorMessage = "La cédula no puede tener más de 10 caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden tener más de 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(50, ErrorMessage = "Los nombres no pueden tener más de 50 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede tener más de 50 caracteres.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "El número de teléfono debe ser de 10 dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(40, ErrorMessage = "La dirección no puede tener más de 40 caracteres.")]
        public string Direccion { get; set; }

        public bool Estado { get; set; }

        [Required(ErrorMessage = "El saldo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El saldo no puede ser negativo.")]
        public decimal Saldo { get; set; }
    }
}