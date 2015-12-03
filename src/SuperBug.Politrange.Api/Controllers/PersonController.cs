using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Persons;

namespace SuperBug.Politrange.Api.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController: ApiController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public IHttpActionResult Get()
        {
            var persons = personService.GetAll();
            var personsViewModel = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

            return Ok(personsViewModel);
        }

        public IHttpActionResult Get(int id)
        {
            var person = personService.GetPersonById(id);
            var personViewModel = Mapper.Map<Person, PersonViewModel>(person);

            return Ok(personViewModel);
        }

        public IHttpActionResult Post(PersonViewModel personViewModel)
        {
            var person = new Person();
            Mapper.Map(personViewModel, person);
            person = personService.AddPerson(person);
            Mapper.Map(person, personViewModel);
            return Ok(personViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            bool isDeleted = personService.RemovePerson(id);

            var httpResponseMessage = isDeleted
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage(HttpStatusCode.NotFound);

            return new ResponseMessageResult(httpResponseMessage);
        }

        [Route("{personId:int}/keywords")]
        public IHttpActionResult GetKeywordsByPerson(int personId)
        {
            var keywords = personService.GetKeywordsByPersonId(personId);
            var keywordsViewModel = Mapper.Map<IEnumerable<Keyword>, IEnumerable<KeywordViewModel>>(keywords);
            return Ok(keywordsViewModel);
        }
    }
}