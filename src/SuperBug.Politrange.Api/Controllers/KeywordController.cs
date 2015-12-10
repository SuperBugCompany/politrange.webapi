using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
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

            return GetResponseMessageResult(isUpdated);
        }

        public IHttpActionResult Delete(int id)
        {
            bool isDeleted = keywordService.Remove(id);

            return GetResponseMessageResult(isDeleted);
        }

        private IHttpActionResult GetResponseMessageResult(bool condition)
        {
            var httpResponseMessage = condition
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage(HttpStatusCode.NotFound);

            return new ResponseMessageResult(httpResponseMessage);
        }
    }
}