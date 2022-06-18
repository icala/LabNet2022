
using Lab.Demo.EF.Entities.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.Demo.EF.MVC.Views
{
    public class UniversitiesController : Controller
    {
        // GET: Universidades
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string pais)
        {
            string Baseurl = "http://universities.hipolabs.com/";
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var encodedPais = HttpUtility.UrlEncode(pais);
                HttpResponseMessage Res = await client.GetAsync($"search?country={encodedPais}");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var universidades = JsonConvert.DeserializeObject<List<UniversidadDTO>>(response);
                    return View("Lista", universidades);
                }
            }
            return View();
        }
    }
}