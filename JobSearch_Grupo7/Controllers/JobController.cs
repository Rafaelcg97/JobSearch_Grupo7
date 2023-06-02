using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobSearch_Grupo7.Controllers
{
    public class JobController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;
        public JobController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }

        [HttpGet]
        [Route("/JobController/JobSearchByArea")]
        public IActionResult JobSearchByArea()
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var citiesList = (from m in _jobsPortalDbContext.City
            select m.cityName).ToList();


            var jobTypesList = (from m in _jobsPortalDbContext.JobType
            select m.jobTypePrompt).ToList();

            var categoriesList = (from a in _jobsPortalDbContext.Area
            select a.areaName).ToList();





            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["categoriesList"] = categoriesList; 
            return View("~/Views/InterfaceObject/SearchJob.cshtml");
        }
    }
}
