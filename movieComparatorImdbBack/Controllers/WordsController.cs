using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.Services;
using Newtonsoft.Json;


namespace movieComparatorImdbBack.Controllers
{

    [ApiController]
    [Route("/Words")]
    public class WordsController : Controller
    {


        private readonly ILogger<WordsController> _logger;

        private readonly IWebHostEnvironment _webHost;

        private readonly WordsService _wordsService;

        public WordsController(ILogger<WordsController> logger,
            IWebHostEnvironment webHost,
            DataContext dataContext
            )
        {
            _logger = logger;
            _webHost = webHost;
            _wordsService = new WordsService(webHost);
        }

        /*
        [HttpGet("/StaticDictionnary")]
        public DictionnaryMov GetStaticDictionnary()
        {
            string contentRootPath = _webHost.ContentRootPath;

            DictionnaryMov dico = new DictionnaryMov();
            string path = contentRootPath + "/ressources/wordlist.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != null)
                {
                    ICollection<string> words = JsonConvert.DeserializeObject<ICollection<string>>(json);
                    foreach (string newWord in words)
                    {
                        WordClass wordClass = new WordClass(newWord);
                        dico.Words.Add(wordClass);
                    }

                }

            }
            return dico;
        }
        */

    }
}