using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Clinica_Medica.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string Role { get; set; } // Nueva propiedad para el rol

        [Display(Name = "¿Eres un humano?")]
        public bool RememberMe { get; set; }

    }
}
