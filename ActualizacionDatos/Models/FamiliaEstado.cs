//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActualizacionDatos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FamiliaEstado
    {
        public int Co_FamiliaEstado { get; set; }
        public Nullable<int> Co_Familia { get; set; }
        public string Tx_Parentesco { get; set; }
        public string Tx_NombreCompleto { get; set; }
        public Nullable<System.DateTime> Fe_Nacimiento { get; set; }
        public string Tx_Entidad { get; set; }
        public string Tx_Cargo { get; set; }
        public Nullable<System.DateTime> Fe_Registro { get; set; }
    
        public virtual Familia Familia { get; set; }
    }
}
