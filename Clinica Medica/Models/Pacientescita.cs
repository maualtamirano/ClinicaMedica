using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinica_Medica.Models
{
    public partial class Pacientescita
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Paciente")]
        public string? NombrePaciente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        [Display(Name = "Fecha y Hora")]
        public DateTime? FechaCita { get; set; }
        [Display(Name = "Motivo")]
        public string? MotivoCita { get; set; }
        [Display(Name = "Doctor")]
        public string? DoctorNombre { get; set; }
    }
}
