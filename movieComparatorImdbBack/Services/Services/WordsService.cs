using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.EntityService;

namespace movieComparatorImdbBack.Services.Services
{
    public class WordsService
    {
        private readonly WordsRepository _wordsRepository;
        public WordsService() {
            this._wordsRepository = new WordsRepository();
        }

        public void AddWords(ICollection<WordClass> words)
        {   
            _wordsRepository.AddWords(words);
        }

        public WordClass getRandomWord()
        {
            WordClass word = _wordsRepository.getRandomWord();
            return word;
        }
    }
}
