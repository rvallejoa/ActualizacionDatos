//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
        public string Tx_FeInicio { get; set; }
        public string Tx_FeFin { get; set; }
        public Nullable<int> Fl_Laborando { get; set; }
    
        public virtual Familia Familia { get; set; }
    }
}
