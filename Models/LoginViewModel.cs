using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto1.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("E-mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "El correo electrónico no es válido.")]
        public string Email_estudiante { get; set; }


        [Required]
        [DisplayName("Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "La contraseña no cumple con los requisitos, debe de tener mínimo 8 caracteres, al menos una letra minúscula, una letra mayúscula y un número.")]
        public string Password_estudiante { get; set; }
    }
}