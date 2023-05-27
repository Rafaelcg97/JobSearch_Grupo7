using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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
                                      select m.companyPicture).Take(10).ToList();

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
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;


            return View();
        }

        public IActionResult SearchJob(Search search)
        {
            ViewData["SalaryRange"] = search.salary.ToString();
            ViewData["ExperienceYear"] = search.experience;


            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();


            var jobTypesList = (from m in _jobsPortalDbContext.JobType
                                select m.jobTypePrompt).ToList();

            
            var jobResultList = (from a in _jobsPortalDbContext.Job
                                       join b in _jobsPortalDbContext.JobType on a.jobTypeId equals b.jobTypeId
                                       join c in _jobsPortalDbContext.City on a.cityId equals c.cityId
                                       join d in _jobsPortalDbContext.Company on a.companyId equals d.companyId
                                 where a.jobSalary <= search.salary && a.jobExperienceYear <= search.experience
                                       select new
                                       {
                                           jobName =a.jobName,
                                           jobDescription=a.jobDescription,
                                           jobSalary = a.jobSalary,
                                           jobExperienceYear = a.jobExperienceYear,
                                           jobRequirements =a.jobRequirements,
                                           jobType = b.jobTypePrompt,
                                           jobCity =c.cityName,
                                           JobCompany = d.companyName,
                                           jobPicture = d.companyPicture

                                       });
            
            if(!search.type.IsNullOrEmpty())
            {
                jobResultList = jobResultList.Where(p => p.jobType == search.type);
            }

            if (!search.ubication.IsNullOrEmpty())
            {
                jobResultList = jobResultList.Where(p => p.jobCity == search.ubication);
            }
            if (!search.descriptionWords.IsNullOrEmpty())
            {
                jobResultList = jobResultList.Where(p => p.jobName.Contains(search.descriptionWords!) || p.jobDescription.Contains(search.descriptionWords));
            }


            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["jobResultList"] = jobResultList.ToList();

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
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;

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
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;


            return View();
        }
    }
}
