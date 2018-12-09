using Inova.Farm.SistemaInterfaceWeb.Models;
using Inova.Farm.SistemaInterfaceWeb.Repository;
using Inova.Farm.SistemaInterfaceWeb.Services;
using Inova.Farm.SistemaInterfaceWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Inova.Farm.SistemaInterfaceWeb.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            //No caso atual como ainda não está feito a etapa de login, o usuário teste está sendo inserido manualmente
            //User.Find();
            GenericRepository<User> usuarioRepository = new GenericRepository<User>();
            GenericRepository<CurrentProduction> productionRepository = new GenericRepository<CurrentProduction>();
            ServiceIrrigation service = new ServiceIrrigation();

            var user = usuarioRepository.EncontrarTodos().FirstOrDefault();
            var productions = productionRepository.EncontrarTodos();
            List<string> stages = new List<string>();
            List<int> soilCondition = new List<int>();

            foreach(var item in productions)
            {
                soilCondition.Add(await service.CalculateIrrigation(user, item));
                stages.Add(item.ProductionPhase.FaseFenologica);

            }
            return View("Index", new IndexViewModel(user.Name, user.MainFruit, user.CurrentProductions.Count, 
                                                    soilCondition, stages, user.FarmName));
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