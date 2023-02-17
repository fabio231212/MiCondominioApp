using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructure.Models
{
    internal partial class EstadoCuentaMetadata
    {
        [Display(Name = "Fecha de Facturación")]
        public Nullable<System.DateTime> FechaFacturacion { get; set; }
    }

    internal partial class PropiedadMetadata
    {
        [Display(Name = "Número de Propiedad")]
        public string NumPropiedad { get; set; }
    }

    internal partial class UsuarioMetadata
    {
        [Display(Name = "Propietario")]
        public string Nombre { get; set; }
    }


}



