using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainingSQL.Website.Models;

namespace TrainingSQL.Website.Controllers
{
    public class CityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string HelloWorld()
        {
            return "Hello World !";
        }

        public string ParallelismTest()
        {
            string html = "";

            var test = new List<string>();

            Parallel.For(0, 1000, delegate (int i) {
                string url = "http://localhost:55709/api/Cities/Test";
            
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                test.Add(html + ">>>" + Task.CurrentId);
            });

            string text = "";
            foreach(var tmp in test)
            {
                text += tmp + "\n";
            }

            return text;
        }

        public int CountCity()
        {
            try
            {
                string url = "http://localhost:55709/api/Cities/Count";
                string html = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                return Int32.Parse(html);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult GetCityFromCode(string code)
        {
            try
            {
                string url = "http://localhost:55709/api/Cities/GetCitiesFromCode/" + code;
                string html = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                List<City> cities = JsonConvert.DeserializeObject<List<City>>(html);

                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
