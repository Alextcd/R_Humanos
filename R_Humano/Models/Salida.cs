//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace R_Humanos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Salida
    {
        public int Id { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public string Tipo_de_salida { get; set; }
        public string Motivo { get; set; }
        public Nullable<System.DateTime> Fecha_salida { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
