using Inova.Farm.SistemaInterfaceWeb.Models;
using Inova.Farm.SistemaInterfaceWeb.Repository;
using Inova.Farm.SistemaInterfaceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inova.Farm.SistemaInterfaceWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //No caso atual como ainda não está feito a etapa de login, o usuário teste está sendo inserido manualmente
            //User.Find();
            GenericRepository<User> usuarioRepository = new GenericRepository<User>();
            var user = usuarioRepository.EncontrarTodos().FirstOrDefault();
            return View("Index", new IndexViewModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}