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
        private IntranetEntities db = new IntranetEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Familia familia, string[] Tx_NombresHermano, string[] Tx_ApellidoPatHermano,string[] Tx_ApellidoMatHermano, string[] Tx_Parentesco, string[] Tx_NombreCompleto,DateTime[] Fe_Nacimiento,string[] Tx_Entidad,string[] Tx_Cargo, string[] EntidadEstatal, string[] Cargo, DateTime[] fecha)
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
                        temporal2.Fe_Registro = DateTime.Now;
                        familia.FamiliaEstado.Add(temporal2);
                        db.SaveChanges();
                    }
                }

                //Se agrega la logica para Cargos publicos
                CargoPublico temporal3;
                if (EntidadEstatal != null)
                {
                    for (int i = 0; i <= EntidadEstatal.Length -1; i++)
                    {
                        temporal3 = new CargoPublico();
                        temporal3.Co_Familia = familia.Co_Familia;
                        temporal3.Tx_Entidad = EntidadEstatal[i];
                        temporal3.Tx_Cargo = Cargo[i];
                        temporal3.Fe_Fecha = fecha[i];
                        temporal3.Fe_Registro = DateTime.Now;
                        familia.CargoPublico.Add(temporal3);
                        db.SaveChanges();
                    }
                }

            }

            return RedirectToAction("RegistroCorrecto");
        }

        public ActionResult RegistroCorrecto()
        {
         

            return View();
        }

        public ActionResult Listado()
        {
            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            ViewBag.usuario= name.Substring(0, position);

            List<Familia>  Listado = db.Familia.Where(x=>x.Fl_Activo == 1).ToList();

            return View(Listado);

        }
    }
}