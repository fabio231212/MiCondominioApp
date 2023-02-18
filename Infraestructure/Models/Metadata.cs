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

        [Display(Name = "Número de Tarjeta")]
        public string Tarjeta { get; set; }

        [Display(Name = "Pagado")]
        public Nullable<bool> Activo { get; set; }


            [DisplayFormat(DataFormatString = "{0:C}")]
            public Nullable<decimal> Total { get; set; }
    }

    internal partial class PropiedadMetadata
    {
        [Display(Name = "Número de Propiedad")]
        public string NumPropiedad { get; set; }

        [Display(Name = "Cantidad de Personas")]
        public Nullable<int> CantPersonas { get; set; }

        [Display(Name = "Cantidad de Carros")]
        public string CantCarros { get; set; }
    }

    internal partial class UsuarioMetadata
    {
        [Display(Name = "Propietario")]
        public string Nombre { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
    }

    internal partial class PlanCobroMetadata
    {
        [Display(Name = "Plan")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Total { get; set; }
    }

    internal partial class RubroCobroMetadata
    {

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Costo { get; set; }
    }


}



