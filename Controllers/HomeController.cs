using CRM_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_System.Controllers {
    public class HomeController : Controller {



        public ViewResult Index() {
            ViewBag.Title = "Главная";
            HomeViewModel obj = new HomeViewModel();
            obj.HiMes = "Добро пожаловать!";

            return View(obj);
        }

    }
}
