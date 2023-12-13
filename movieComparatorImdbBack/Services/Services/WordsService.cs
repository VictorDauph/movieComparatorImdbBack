using Microsoft.AspNetCore;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.EntityService;
using Newtonsoft.Json;

namespace movieComparatorImdbBack.Services.Services
{
    public class WordsService
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly WordsRepository _wordsRepository;
        public WordsService(IWebHostEnvironment webHost) {
            this._wordsRepository = new WordsRepository();
            _webHost = webHost;
        }

        public void AddWords(ICollection<WordClass> words)
        {   
            _wordsRepository.AddWords(words);
        }

        public WordClass getRandomWord()
        {
            WordClass? word = _wordsRepository.getRandomWord();
            if (word == null)
            {
                this.initWordsTable(_webHost);
                word = _wordsRepository.getRandomWord();
            }
            return word;
        }

        public void initWordsTable(IWebHostEnvironment _webHost)
        {
            Console.WriteLine("init words table");
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
                    this.AddWords(dico.Words);
                }

            }
        }
    }
}
