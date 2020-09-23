using MakingWavesTest.Models.ViewModels;
using MakingWavesTest.Service.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MakingWavesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IColorService _colorService;

        public HomeController(IColorService colorService)
        {
            _colorService = colorService;
        }
        public ActionResult Index()
        {
            var groupedColors = new List<GroupedColorsViewModel>(); 
            try
            {
               groupedColors = _colorService.GroupedColors();
                return View(groupedColors); 
            }
            catch (Exception)
            {
                return View();
            }


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