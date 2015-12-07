using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Keywords;
using SuperBug.Politrange.Services.Persons;

namespace SuperBug.Politrange.Api.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController: ApiController
    {
        private readonly IPersonService personService;
        private readonly IKeywordService keywordService;

        public PersonController(IPersonService personService,IKeywordService keywordService)
        {
            this.personService = personService;
            this.keywordService = keywordService;
        }

        public IHttpActionResult Get()
        {
            var persons = personService.GetAll();
            var personsViewModel = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

            return Ok(personsViewModel);
        }

        public IHttpActionResult Get(int id)
        {
            var person = personService.GetById(id);
            var personViewModel = Mapper.Map<Person, PersonViewModel>(person);

            return Ok(personViewModel);
        }

        public IHttpActionResult Post(PersonViewModel personViewModel)
        {
            var person = new Person();
            Mapper.Map(personViewModel, person);
            person = personService.Add(person);
            Mapper.Map(person, personViewModel);
            return Ok(personViewModel);
        } 

        public IHttpActionResult Delete(int id)
        {
            bool isDeleted = personService.Remove(id);

            var httpResponseMessage = isDeleted
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage(HttpStatusCode.NotFound);

            return new ResponseMessageResult(httpResponseMessage);
        }

        [Route("{personId:int}/keywords")]
        public IHttpActionResult GetKeywordsByPerson(int personId)
        {
            var keywords = keywordService.GetByPersonId(personId);
            var keywordsViewModel = Mapper.Map<IEnumerable<Keyword>, IEnumerable<KeywordViewModel>>(keywords);
            return Ok(keywordsViewModel);
        }

        [Route("{personId:int}/keywords")]
        public IHttpActionResult PostKeyword(int personId, KeywordViewModel keywordViewModel)
        {
            var keyword = Mapper.Map<KeywordViewModel, Keyword>(keywordViewModel);
            keyword.PersonId = personId;
            keyword = keywordService.Add(keyword);
            Mapper.Map(keyword, keywordViewModel);

            return Ok(keywordViewModel);      
        }
    }
}