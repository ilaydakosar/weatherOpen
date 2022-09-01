using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherOpen.Models;

namespace WeatherOpen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
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
        public HavaDurumu HavaDurumuGetir()
        {
            using (var client = new System.Net.WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                var responseString = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=Ankara,TR&units=metric&appid=SECRET_KEY");

                var hava = JsonConvert.DeserializeObject<HavaDurumu>(responseString);
                hava.weather[0].icon = @"http://openweathermap.org/img/w/" + hava.weather[0].icon + ".png";
                return hava;
            }
        }
       
    }
}