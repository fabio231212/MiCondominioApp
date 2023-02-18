//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Collections.Generic;
    

    public partial class Propiedad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Propiedad()
        {
            this.Factura = new HashSet<Factura>();
        }
    
        public int Id { get; set; }
        public string NumPropiedad { get; set; }
        public Nullable<int> FK_Usuario { get; set; }
        public Nullable<int> CantPersonas { get; set; }
        public string CantCarros { get; set; }
        public Nullable<int> FK_EstadoPropiedad { get; set; }

    
        public virtual EstadoPropiedad EstadoPropiedad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
