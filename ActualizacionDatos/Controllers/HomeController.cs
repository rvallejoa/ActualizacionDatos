using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ActualizacionDatos.Models;


namespace ActualizacionDatos.Controllers
{


    [Authorize]
    public class HomeController : Controller
    {
        //Se actualiza el link del GITHUB


        private IntranetEntities db = new IntranetEntities();

        public ActionResult Index()
        {

            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            string usuario = name.Substring(0, position);

            //Obtener nombre de usuario logeado
            var usuarioDet = db.Usuario.Where(x => x.No_Usuario == usuario).FirstOrDefault();

            ViewBag.nombreUsuario = usuarioDet.Tx_Nombre;


            Familia fam = db.Familia.Where(x => x.Fl_Activo == 1 && x.No_Usuario == usuario).FirstOrDefault();
            if (fam == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("HomeEdit", "Edit");
            }

        }

        [HttpPost]
        public ActionResult Index(Familia familia, string[] Tx_NombresHermano, string[] Tx_ApellidoPatHermano, string[] Tx_ApellidoMatHermano,
            string[] Tx_Parentesco, string[] Tx_NombreCompleto, DateTime[] Fe_Nacimiento, string[] Tx_Entidad, string[] Tx_Cargo, string[] EntidadEstatal,
            string[] Cargo, string[] Tx_FeInicio, string[] Tx_FeFin, string[] Tx_FeInicioCargo, string[] Tx_FeFinCargo, int[] Fl_Laborando, int[] Fl_LaborandoCargo)
        {
            string name = User.Identity.Name;
            int position = name.IndexOf('@');

            familia.No_Usuario = name.Substring(0, position);
            familia.Fe_Registro = DateTime.Now;
            familia.Fl_Activo = 1;
            db.Familia.Add(familia);


            if (db.SaveChanges() == 1)
            {
                Hermano temporal;
                if (Tx_NombresHermano != null)
                {
                    for (int i = 0; i <= Tx_NombresHermano.Length - 1; i++)
                    {
                        temporal = new Hermano();
                        temporal.Co_Familia = familia.Co_Familia;
                        temporal.Tx_NombresHermano = Tx_NombresHermano[i];
                        temporal.Tx_ApellidoPatHermano = Tx_ApellidoPatHermano[i];
                        temporal.Tx_ApellidoMatHermano = Tx_ApellidoMatHermano[i];
                        temporal.Fe_Registro = DateTime.Now;
                        familia.Hermano.Add(temporal);
                        db.SaveChanges();
                    }
                }


                if (familia.Fl_CosanguiniedadEstado == 1)
                {
                    FamiliaEstado temporal2;
                    if (Tx_Parentesco != null)
                    {
                        for (int i = 0; i <= Tx_Parentesco.Length - 1; i++)
                        {
                            temporal2 = new FamiliaEstado();
                            temporal2.Co_Familia = familia.Co_Familia;
                            temporal2.Tx_Parentesco = Tx_Parentesco[i];
                            temporal2.Tx_NombreCompleto = Tx_NombreCompleto[i];
                            temporal2.Fe_Nacimiento = Fe_Nacimiento[i];
                            temporal2.Tx_Entidad = Tx_Entidad[i];
                            temporal2.Tx_Cargo = Tx_Cargo[i];
                            temporal2.Tx_FeInicio = Tx_FeInicio[i];
                            temporal2.Tx_FeFin = Tx_FeFin[i];
                            temporal2.Fl_Laborando = Fl_Laborando[i];
                            temporal2.Fe_Registro = DateTime.Now;
                            familia.FamiliaEstado.Add(temporal2);
                            db.SaveChanges();
                        }
                    }
                }

                if (familia.Fl_CargoPublico == 1)
                {
                    //Se agrega la logica para Cargos publicos
                    CargoPublico temporal3;
                    if (EntidadEstatal != null)
                    {
                        for (int i = 0; i <= EntidadEstatal.Length - 1; i++)
                        {
                            temporal3 = new CargoPublico();
                            temporal3.Co_Familia = familia.Co_Familia;
                            temporal3.Tx_Entidad = EntidadEstatal[i];
                            temporal3.Tx_Cargo = Cargo[i];
                            //temporal3.Fe_Fecha = fecha[i];
                            temporal3.Tx_FeInicioCargo = Tx_FeInicioCargo[i];
                            temporal3.Tx_FeFinCargo = Tx_FeFinCargo[i];
                            temporal3.Fl_LaborandoCargo = Fl_LaborandoCargo[i];
                            temporal3.Fe_Registro = DateTime.Now;
                            familia.CargoPublico.Add(temporal3);
                            db.SaveChanges();
                        }
                    }
                }



            }

            return RedirectToAction("RegistroCorrecto");
        }

        public ActionResult RegistroCorrecto()
        {


            return View();
        }

        //public ActionResult Listado()
        //{
        //    string name = User.Identity.Name;
        //    int position = name.IndexOf('@');
        //    ViewBag.usuario = name.Substring(0, position);

        //    DateTime thisDay = DateTime.Today;
        //    ViewBag.fecha = thisDay.ToString("D");

        //    List<Familia> Listado = db.Familia.Where(x => x.Fl_Activo == 1).ToList();
        //   // List<Usp_ListadoFamilia1_Result> ListadoCopy = db.Usp_ListadoFamilia().ToList();
        //    return View(Listado);

        //}
        //public ActionResult ListadoCopy()
        //{
        //    string name = User.Identity.Name;
        //    int position = name.IndexOf('@');
        //    ViewBag.usuario = name.Substring(0, position);

        //    DateTime thisDay = DateTime.Today;
        //    ViewBag.fecha = thisDay.ToString("D");

        //    List<Usp_ListadoFamilia_Result> ListadoCopy = db.Usp_ListadoFamilia().ToList();

        //    return View(ListadoCopy);

        //}
        //public ActionResult Listado()
        //{
        //    string name = User.Identity.Name;
        //    int position = name.IndexOf('@');
        //    ViewBag.usuario = name.Substring(0, position);

        //    DateTime thisDay = DateTime.Today;
        //    ViewBag.fecha = thisDay.ToString("D");

        //    // Obtener los resultados del stored procedure Usp_ListadoFamilia
        //    List<Usp_ListadoFamilia5_Result> resultados = db.Usp_ListadoFamilia5().ToList();
        //    List<CargoPublico> Listado = db.CargoPublico.ToList();
        //    // Crear una lista de Familia donde fusionaremos las propiedades
        //    List<Familia> familias = new List<Familia>();
        //     familias =db.Familia.ToList();
        //    // Iterar sobre los resultados del procedimiento almacenado
        //    foreach (var resultado in resultados)
        //    {
        //        // Crear una nueva instancia de Familia
        //        Familia familia = new Familia();
                
        //        // Asignar las propiedades específicas de Usp_ListadoFamilia_Result a la instancia de Familia
        //        familia.Tx_NombreCompleto = resultado.Tx_NombreCompleto;
        //        familia.No_Cargo = resultado.No_Cargo;
        //        familia.ApellidosMadre = resultado.ApellidosMadre;
        //        familia.ApellidosPadre = resultado.ApellidosPadre;
        //        familia.Hermanos = resultado.Hermanos;
        //        familia.Pareja = resultado.Pareja;
        //        familia.Suegro = resultado.Suegro;
        //        familia.Suegra = resultado.Suegra;
        //        familia.FamiliarEstadoYo= resultado.FamiliarEstadoYo;
        //        familia.CargoEstado= resultado.CargoEstado;
        //        familia.EstadoYo = resultado.EstadoYo;
        //        familia.Registro= resultado.Registro;
        //        familia.Actualizacion= resultado.Actualizacion;
               
                                                                                                                   
                                                                                                                
        //        familias.Add(familia);
        //    }

        //    return View(familias);
        //}

        public ActionResult Listado()
        {
            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            ViewBag.usuario = name.Substring(0, position);

            DateTime thisDay = DateTime.Today;
            ViewBag.fecha = thisDay.ToString("D");

            // Obtener los resultados del stored procedure Usp_ListadoFamilia5
            List<Usp_ListadoFamilia11_Result> resultados = db.Usp_ListadoFamilia11().ToList();

            return View(resultados);
        }




    }
}