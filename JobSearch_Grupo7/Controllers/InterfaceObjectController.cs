using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace JobSearch_Grupo7.Controllers
{
    public class InterfaceObjectController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;

        public InterfaceObjectController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }
        public IActionResult Index()
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject 
                                where m.objectName == "logo" select m.objectContentImage).First();

            var bannerInicial = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "banner"
                           select new { m.objectContentImage, m.objectContentText}).First();

            List<byte[]> companyPictures = (from m in _jobsPortalDbContext.Company 
                                      select m.companyPicture).Take(5).ToList();

            var citiesList = (from m in _jobsPortalDbContext.City
                                 select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            int countCompanies =  _jobsPortalDbContext.Company.Count();
            int countEmployees = _jobsPortalDbContext.Employee.Count();
            int countApplication = _jobsPortalDbContext.Application.Count();
            int countJobs = (from m in _jobsPortalDbContext.Job where m.jobIsActive == true select m).Count();


            byte[] banner = bannerInicial.objectContentImage;
            string bannerText = bannerInicial.objectContentText;

            ViewData["logoImage"] = logo;
            ViewData["bannerImage"] = banner;
            ViewData["bannerText"] = bannerText;
            ViewData["companyPictures"] = companyPictures;
            ViewData["countCompanies"] = countCompanies;
            ViewData["countEmployees"] = countEmployees;
            ViewData["countApplications"] = countApplication;
            ViewData["countJobs"] = countJobs;
            ViewData["citiesList"] = new SelectList(citiesList,"ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 500;
            ViewData["ExperienceYear"] = 4;


            return View();
        }

        public IActionResult SearchJob(Search search)
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();


            var jobTypesList = (from m in _jobsPortalDbContext.JobType
                                select m.jobTypePrompt).ToList();

            /*
            var jobResultList = (from a in _jobsPortalDbContext.Job
                                       join b in _jobsPortalDbContext.JobType on a.jobTypeId equals b.jobTypeId
                                       join c in _jobsPortalDbContext.City on a.cityId equals c.cityId
                                       where 
                                       if (search.descriptionWords.IsNullOrEmpty(), )
                                       a.jobDescription!.Contains(search.descriptionWords!) && a.jobSalary>=search.salary
                                       select c).ToList();
            */

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = search.salary.ToString();
            ViewData["ExperienceYear"] = search.experience;

            return View();
        }

        public IActionResult SignUp()
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();


            var jobTypesList = (from m in _jobsPortalDbContext.JobType
                                select m.jobTypePrompt).ToList();

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 500;
            ViewData["ExperienceYear"] = 4;

            return View();
        }

        public IActionResult SignIn()
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();


            var jobTypesList = (from m in _jobsPortalDbContext.JobType
                                select m.jobTypePrompt).ToList();

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 500;
            ViewData["ExperienceYear"] = 4;


            return View();
        }
    }
}
