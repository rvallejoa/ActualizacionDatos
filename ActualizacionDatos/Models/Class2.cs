using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActualizacionDatos.Models
{
    public class FamiliaViewModel
    {
        public int Co_FamiliaEstado { get; set; }
        public int Co_CargoPublico { get; set; }
        public Familia Familia { get; set; }
        public List<FamiliaEstado> FamiliaEstado { get; set; }
        public List<CargoPublico> CargoPublico { get; set; }
        public string Tx_NombreCompleto { get; set; }
        public string No_Cargo { get; set; }
        public string ApellidosPadre { get; set; }
        public string ApellidosMadre { get; set; }
        public string Hermanos { get; set; }
        public string Pareja { get; set; }
        public string Suegro { get; set; }
        public string Suegra { get; set; }
        public Nullable<int> FamiliaEstadoConsan { get; set; }
        public Nullable<int> CargoEstado { get; set; }
        public string Registro { get; set; }
        public string Actualizacion { get; set; }
        public string pariente { get; set; }
        public string nombrefamiliar { get; set; }
        public Nullable<System.DateTime> fechafamiliar { get; set; }
        public string entidadfamiliar { get; set; }
        public string cargopublicofamiliar { get; set; }
        public string entidadyo { get; set; }
        public string cargopublicoyo { get; set; }
        public string fechacargo { get; set; }
        public int? Co_Familia { get; internal set; }
    }
}