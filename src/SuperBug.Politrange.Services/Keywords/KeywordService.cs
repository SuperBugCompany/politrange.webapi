﻿using System.Collections.Generic;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Keywords
{
    public class KeywordService: IKeywordService
    {
        private readonly IKeywordRepository keywordRepository;

        public KeywordService(IKeywordRepository keywordRepository)
        {
            this.keywordRepository = keywordRepository;
        }

        public IEnumerable<Keyword> GetKeywords()
        {
            return keywordRepository.GetAll();
        }

        public Keyword AddKeyword(Keyword keyword)
        {
            return keywordRepository.Add(keyword);
        }

        public bool RemoveKeyword(int id)
        {
            return keywordRepository.Delete(id);
        }
    }

    public interface IKeywordService
    {
        IEnumerable<Keyword> GetKeywords();
        Keyword AddKeyword(Keyword keyword);
        bool RemoveKeyword(int id);
    }
}