using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActualizacionDatos.Models
{
    public class ListadoViewModel
    {
        public IEnumerable<Familia> Familias { get; set; }
        public IEnumerable<Usp_ListadoFamilia1_Result> Resultados { get; set; }
    }

}