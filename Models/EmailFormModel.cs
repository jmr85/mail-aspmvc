using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaMailMVC.Models
{
    public class EmailFormModel
    {
       
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Mail ingresado invalido, tiene que ser este formato: pepito@mail.com, trata que sea un mail existente")]
        [Required, Display(Name = "Para"), EmailAddress]
        public string FromEmail { get; set; }

        [RegularExpression(@"[a-zA-ZñÑ\s]{4,30}", ErrorMessage = "Minimo 4 letras")]
        [Required, Display(Name = "Asunto")]
        public string FromSubject { get; set; }

        [Required, Display(Name = "Mensaje")]
        public string Message { get; set; }
    }
}