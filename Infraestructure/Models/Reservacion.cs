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
    
    public partial class Reservacion
    {
        public int FK_Usuario { get; set; }
        public int FK_AreaComunal { get; set; }
        public System.DateTime FechaEntrada { get; set; }
        public int Id { get; set; }
        public Nullable<int> FK_Estado { get; set; }
        public System.DateTime FechaSalida { get; set; }
        public bool Cancelada { get; set; }
        public string Nota { get; set; }
    
        public virtual AreaComunal AreaComunal { get; set; }
        public virtual EstadoReservacion EstadoReservacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
