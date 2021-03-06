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

        public IEnumerable<Keyword> GetAll()
        {
            return keywordRepository.GetAll();
        }

        public Keyword Add(Keyword keyword)
        {
            return keywordRepository.Add(keyword);
        }

        public bool Remove(int id)
        {
            return keywordRepository.Delete(id);
        }

        public bool Update(Keyword keyword)
        {
            return keywordRepository.Update(keyword);
        }

        public IEnumerable<Keyword> GetByPersonId(int personId)
        {
            return keywordRepository.GetMany(x => x.PersonId == personId);
        }
    }
}