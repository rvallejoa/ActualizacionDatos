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
    
    public partial class CargoPublico
    {
        public int Co_CargoPublico { get; set; }
        public Nullable<int> Co_Familia { get; set; }
        public string Tx_Entidad { get; set; }
        public string Tx_Cargo { get; set; }
        public Nullable<System.DateTime> Fe_Fecha { get; set; }
        public Nullable<System.DateTime> Fe_Registro { get; set; }
        public string Tx_FeInicioCargo { get; set; }
        public string Tx_FeFinCargo { get; set; }
        public Nullable<int> Fl_LaborandoCargo { get; set; }
    
        public virtual Familia Familia { get; set; }
    }
}
