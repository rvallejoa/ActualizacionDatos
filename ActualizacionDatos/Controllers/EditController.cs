using ActualizacionDatos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActualizacionDatos.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        private IntranetEntities db = new IntranetEntities();
        // GET: Edit
        public ActionResult HomeEdit()
        {
            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            var usuario= name.Substring(0, position);
            ViewBag.usuario = usuario;


            var familia = db.Familia.Where(x => x.No_Usuario == usuario && x.Fl_Activo==1).FirstOrDefault();

            //Obtener nombre de usuario logeado
            var usuarioDet = db.Usuario.Where(x => x.No_Usuario == usuario).FirstOrDefault();
          
            ViewBag.nombreUsuario = usuarioDet.Tx_Nombre;

            return View(familia);
          
        }

        [HttpPost]
        public ActionResult HomeEdit(Familia familia, string[] Tx_NombresHermano, string[] Tx_ApellidoPatHermano, string[] Tx_ApellidoMatHermano, 
            string[] Tx_Parentesco, string[] Tx_NombreCompleto, DateTime[] Fe_Nacimiento, string[] Tx_Entidad, string[] Tx_Cargo, 
            string[] EntidadEstatal, string[] Cargo, string[] Tx_FeInicio, string[] Tx_FeFin, string[] Tx_FeInicioCargo, string[] Tx_FeFinCargo, int[] Fl_Laborando, int[] Fl_LaborandoCargo)
        {
            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            var usuario = name.Substring(0, position);
            ViewBag.usuario = usuario;
            //Obtener nombre de usuario logeado
            var usuarioDet = db.Usuario.Where(x => x.No_Usuario == usuario).FirstOrDefault();
            ViewBag.nombreUsuario = usuarioDet.Tx_Nombre;


            familia.Fe_Actualizacion = DateTime.Now;
            familia.Fl_Actualizacion2 = 1;
            db.Entry(familia).State = EntityState.Modified;



            if (Tx_NombresHermano != null)
            {
                //Eliminando hermanos
                foreach (var item in db.Hermano.Where(x => x.Co_Familia == familia.Co_Familia))
                {
                    Hermano gct = db.Hermano.Find(item.Co_Hermano);
                    db.Hermano.Remove(gct);
                }

                db.SaveChanges();
                // Agregando Hermanos

                Hermano _hermano;
                for (int i = 0; i <= Tx_NombresHermano.Length - 1; i++)
                {
                    _hermano = new Hermano();
                    _hermano.Co_Familia = familia.Co_Familia;
                    _hermano.Tx_NombresHermano = Tx_NombresHermano[i];
                    _hermano.Tx_ApellidoPatHermano = Tx_ApellidoPatHermano[i];
                    _hermano.Tx_ApellidoMatHermano = Tx_ApellidoMatHermano[i];
                    _hermano.Fe_Registro = DateTime.Now;
                    db.Entry(familia).State = EntityState.Modified;
                    db.Hermano.Add(_hermano);
                }

            }


            if (familia.Fl_CosanguiniedadEstado==1)
            {
                if (Tx_Parentesco != null)
                {
                    //Eliminando familiaestado
                    foreach (var item in db.FamiliaEstado.Where(x => x.Co_Familia == familia.Co_Familia))
                    {
                        FamiliaEstado gct = db.FamiliaEstado.Find(item.Co_FamiliaEstado);
                        db.FamiliaEstado.Remove(gct);
                    }

                    db.SaveChanges();
                    // Agregando familiestado

                    FamiliaEstado _familiaE;
                    for (int i = 0; i <= Tx_Parentesco.Length - 1; i++)
                    {
                        _familiaE = new FamiliaEstado();
                        _familiaE.Co_Familia = familia.Co_Familia;
                        _familiaE.Tx_Parentesco = Tx_Parentesco[i];
                        _familiaE.Tx_NombreCompleto = Tx_NombreCompleto[i];
                        _familiaE.Fe_Nacimiento = Fe_Nacimiento[i];
                        _familiaE.Tx_Entidad = Tx_Entidad[i];
                        _familiaE.Tx_Cargo = Tx_Cargo[i];
                        _familiaE.Tx_FeInicio = Tx_FeInicio[i];
                        _familiaE.Tx_FeFin = Tx_FeFin[i];
                        _familiaE.Tx_FeFin = Tx_FeFin[i];
                        _familiaE.Fl_Laborando = Fl_Laborando[i];
                        _familiaE.Fe_Registro = DateTime.Now;
                        db.Entry(familia).State = EntityState.Modified;
                        db.FamiliaEstado.Add(_familiaE);

                    }
                }
            }

            if (familia.Fl_CargoPublico == 1)
            {
                if (EntidadEstatal != null)
                {
                    //Eliminando cargo
                    foreach (var item in db.CargoPublico.Where(x => x.Co_Familia == familia.Co_Familia))
                    {
                        CargoPublico gct = db.CargoPublico.Find(item.Co_CargoPublico);
                        db.CargoPublico.Remove(gct);
                    }

                    db.SaveChanges();
                    // Agregando cargo

                    CargoPublico _cargo;
                    for (int i = 0; i <= EntidadEstatal.Length - 1; i++)
                    {

                        _cargo = new CargoPublico();
                        _cargo.Co_Familia = familia.Co_Familia;
                        _cargo.Tx_Entidad = EntidadEstatal[i];
                        _cargo.Tx_Cargo = Cargo[i];
                        // _cargo.Fe_Fecha = fecha[i];
                        _cargo.Tx_FeInicioCargo = Tx_FeInicioCargo[i];
                        _cargo.Tx_FeFinCargo = Tx_FeFinCargo[i];
                        _cargo.Fl_LaborandoCargo = Fl_LaborandoCargo[i];
                        _cargo.Fe_Registro = DateTime.Now;
                        db.Entry(familia).State = EntityState.Modified;
                        db.CargoPublico.Add(_cargo);

                    }
                }
            }

            db.SaveChanges();


            return View(familia);
        }



        public ActionResult ConfirmarInfo(int codigoUsuario)
        {

            string name = User.Identity.Name;
            int position = name.IndexOf('@');
            var usuario = name.Substring(0, position);
            ViewBag.usuario = usuario;

            var familia = db.Familia.Where(x => x.Co_Familia == codigoUsuario && x.Fl_Activo == 1).FirstOrDefault();

            familia.Fe_Actualizacion = DateTime.Now;
            familia.Fl_Actualizacion2 = 1;
           

            db.Entry(familia).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("HomeEdit");
        }
    }
}