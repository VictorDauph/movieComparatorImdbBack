using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using movieComparatorImdbBack.models;
using Newtonsoft.Json;


namespace movieComparatorImdbBack.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {


        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IWebHostEnvironment _webHost;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public DictionnaryMov Get()
        {
            string contentRootPath = _webHost.ContentRootPath;



            DictionnaryMov dico = new DictionnaryMov();
            string path = contentRootPath + "/ressources/wordlist.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if(json != null) {
                    dico.Words = JsonConvert.DeserializeObject<ICollection<string>>(json);
                }
                
            }
            return dico;
        }
    }
}