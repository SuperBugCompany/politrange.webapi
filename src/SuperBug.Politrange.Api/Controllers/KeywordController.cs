﻿using System.Web.Http;
using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Keywords;

namespace SuperBug.Politrange.Api.Controllers
{
    public class KeywordController:ApiController
    {
        private readonly IKeywordService keywordService;

        public KeywordController(IKeywordService keywordService)
        {
            this.keywordService = keywordService;
        }

        public IHttpActionResult Put(int id, KeywordViewModel keywordViewModel)
        {
            var keyword = Mapper.Map<KeywordViewModel, Keyword>(keywordViewModel);
            keyword.KeywordId = id;

            bool isUpdated = keywordService.Update(keyword);
            return Ok(isUpdated);
        }

        public IHttpActionResult Delete(int id)
        {
            bool isUpdated = keywordService.RemoveKeyword(id);

            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}