using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructure.Models
{

    internal partial class ReservacionMetadata
    {

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Area Comunal")]
        public int FK_AreaComunal { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Fecha de Entrada")]
        public Nullable<System.DateTime> FechaEntrada { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Fecha de Salida")]
        public Nullable<System.DateTime> FechaSalida { get; set; }
    }

    internal partial class EstadoCuentaMetadata
    {

        [Display(Name = "Fecha de Facturación")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<System.DateTime> FechaFacturacion { get; set; }

       // [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Número de Tarjeta")]
        public string Tarjeta { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Pagado")]
        public Nullable<bool> Activo { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Total { get; set; }

        [Display(Name = "Plan de Cobro")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> FK_PlanCobro { get; set; }
        [Display(Name = "Propiedad")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> FK_Propiedad { get; set; }
    }

    internal partial class PropiedadMetadata
    {

        [UIHint("Fecha")]
        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Fecha de Inicio")]
        public Nullable<System.DateTime> FechaInicio { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Número de Propiedad")]
        public string NumPropiedad { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
        [Display(Name = "Cantidad de Personas")]
        public Nullable<int> CantPersonas { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
        [Display(Name = "Cantidad de Carros")]
        public string CantCarros { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Propietario")]
        public Nullable<int> FK_Usuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Estado de la propiedad")]
        public Nullable<int> FK_EstadoPropiedad { get; set; }

        public virtual EstadoPropiedad EstadoPropiedad { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Display(Name = "Plan de cobro")]
        public Nullable<int> FK_PlanCobro { get; set; }

    }


    internal partial class UsuarioMetadata
    {

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Propietario")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }


        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Clave { get; set; }


        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> FK_Rol { get; set; }


        [Display(Name = "Activo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<bool> Activo { get; set; }

    }


    internal partial class PlanCobroMetadata
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[a-zA-Z]{3,}$", ErrorMessage = "Solo acepta letras (Minímo tres)")]
        [Display(Name = "Plan")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "solo acepta números, con dos decimales")]
        public Nullable<decimal> Total { get; set; }

        [Display(Name = "Rubros de Cobro")]
        public virtual ICollection<RubroCobro> RubroCobro { get; set; }
    }

    internal partial class InformacionMetadata
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
    }

    internal partial class ArchivoMetadata
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public byte[] Contenido { get; set; }

 
    }

    internal partial class RubroCobroMetadata
    {

        [DisplayFormat(DataFormatString = "{0:C}")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "solo acepta números, con dos decimales")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<decimal> Costo { get; set; }


        [Display(Name = "Rubro")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; }
    }

    internal partial class RolMetadata
    {
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; }
    }

    internal partial class IncidenciasMetadata
    {

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> FK_Usuario { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public int FK_Estado { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Registrada")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}



