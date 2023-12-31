﻿using Microsoft.Identity.Client;
using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Services.EntityService
{
    public class WordsRepository
    {
        DataContext _dataContext;
        public WordsRepository()
        {
            this._dataContext = new DataContext();
        }

        public void AddWords(ICollection<WordClass> words)
        {
            //Product product = new Product(productDto);
            //context.Add(product);

            IEnumerable<WordClass> oldWords = from word in _dataContext.Words
                                              select word;
            if(oldWords.Count() > 0)
            {
                foreach(WordClass word in oldWords)
                {
                    _dataContext.Words.Remove(word);
                }
                _dataContext.SaveChanges();
            }

            foreach(WordClass word in words)
            {
                _dataContext.Add(word);
                _dataContext.SaveChanges();
            }

        }
        public WordClass? getRandomWord()
        {
            WordClass? wordRand;
            try
            {
                wordRand = _dataContext.Words
                                    .FromSql(
                                            $"SELECT TOP 1 * FROM dbo.Words ORDER BY NEWID()  ")
                                    .First();
            }catch(Exception ex)
            {
                wordRand = null;
            }
            
            return wordRand;
        }

        public void deleteWord(WordClass word )
        {
            _dataContext.Remove(word);
            _dataContext.SaveChanges() ;
        }
    }
}
