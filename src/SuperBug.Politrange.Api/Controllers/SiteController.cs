using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Sites;

namespace SuperBug.Politrange.Api.Controllers
{
    public class SiteController: ApiController
    {
        private readonly ISiteService siteService;

        public SiteController(ISiteService siteService)
        {
            this.siteService = siteService;
        }

        public IHttpActionResult Get()
        {
            var sites = siteService.GetAll();
            var sitesViewModel = Mapper.Map<IEnumerable<Site>, IEnumerable<SiteViewModel>>(sites);

            return Ok(sitesViewModel);
        }

        public IHttpActionResult Get(int id)
        {
            var site = siteService.GetSitebyId(id);
            var siteViewModel = Mapper.Map<Site, SiteViewModel>(site);

            return Ok(siteViewModel);
        }

        public IHttpActionResult Post(SiteViewModel siteViewModel)
        {
            var site = Mapper.Map<SiteViewModel, Site>(siteViewModel);
            site = siteService.AddSite(site);
            siteViewModel = Mapper.Map<Site, SiteViewModel>(site);

            return Ok(siteViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            bool isDelete = siteService.Delete(id);

            if (isDelete)
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