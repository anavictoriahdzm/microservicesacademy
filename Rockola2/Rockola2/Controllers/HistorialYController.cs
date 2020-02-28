using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rockola2.Models;

namespace Rockola2.Controllers
{
    public class HistorialYController : Controller
    {
        //URL donde se ubica nuestra API
        string Baseurl = "http://localhost:7012/";

        public async Task<ActionResult> Index()
        {
            List<HistorialY> HistorialInfo = new List<HistorialY>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama todo el contenido usando el HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/HistorialTs/");
                if(Res.IsSuccessStatusCode)
                {
                    //Si Rest = true entra y asigna los datos
                    var HistorialResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializar el api y almacena los datos
                    HistorialInfo = JsonConvert.DeserializeObject<List<HistorialY>>(HistorialResponse);
                }
                //Muestra la lista de todos los usuarios
                return View(HistorialInfo);
            }
        }
    }
}