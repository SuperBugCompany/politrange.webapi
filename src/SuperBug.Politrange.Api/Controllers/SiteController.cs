using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Pages;
using SuperBug.Politrange.Services.Sites;

namespace SuperBug.Politrange.Api.Controllers
{
    [RoutePrefix("api/sites")]
    public class SiteController: ApiController
    {
        private readonly IPageService pageService;
        private readonly ISiteService siteService;

        public SiteController(ISiteService siteService, IPageService pageService)
        {
            this.siteService = siteService;
            this.pageService = pageService;
        }

        public IHttpActionResult Get()
        {
            var sites = siteService.GetAll();
            var sitesViewModel = Mapper.Map<IEnumerable<Site>, IEnumerable<SiteViewModel>>(sites);

            return Ok(sitesViewModel);
        }

        public IHttpActionResult Get(int id)
        {
            var site = siteService.GetbyId(id);
            var siteViewModel = Mapper.Map<Site, SiteViewModel>(site);

            return Ok(siteViewModel);
        }

        public IHttpActionResult Post(SiteViewModel siteViewModel)
        {
            var site = Mapper.Map<SiteViewModel, Site>(siteViewModel);
            site = siteService.Add(site);
            siteViewModel = Mapper.Map<Site, SiteViewModel>(site);

            return Ok(siteViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            bool isDelete = siteService.Remove(id);

            if (isDelete)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("{siteId:int}/pages")]
        public IHttpActionResult GetPagesBySite(int siteId)
        {
            var pages = pageService.GetBySiteId(siteId);
            var pagesViewModel = Mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(pages);

            return Ok(pagesViewModel);
        }
    }
}