﻿using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.X86;

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
            ViewData["UserName"] = HttpContext.Session.GetString("userName");


            return View();
        }

        public IActionResult SearchJob(Search search, string area="Todas", string ordenDef="Default")
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


            var jobResultList = (from a in _jobsPortalDbContext.Job
                                       join b in _jobsPortalDbContext.JobType on a.jobTypeId equals b.jobTypeId
                                       join c in _jobsPortalDbContext.City on a.cityId equals c.cityId
                                       join d in _jobsPortalDbContext.Company on a.companyId equals d.companyId
                                       join e in _jobsPortalDbContext.Area on a.areaId equals e.areaId
                                 where a.jobSalary <= search.salary && a.jobExperienceYear <= search.experience
                                       select new
                                       {
                                           jobId = a.jobId,
                                           jobName =a.jobName,
                                           jobDescription=a.jobDescription,
                                           jobSalary = a.jobSalary,
                                           jobExperienceYear = a.jobExperienceYear,
                                           jobRequirements =a.jobRequirements,
                                           jobType = b.jobTypePrompt,
                                           jobCity =c.cityName,
                                           JobCompany = d.companyName,
                                           jobPicture = d.companyPicture,
                                           jobArea = e.areaName,
                                           jobPosted = a.jobPosted,
                                           jobCompanyId=d.companyId
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
                jobResultList = jobResultList.Where(p => p.jobName.Contains(search.descriptionWords!) || p.jobDescription.Contains(search.descriptionWords!));
            }
            if(area != "Todas")
            {
                jobResultList = jobResultList.Where(p => p.jobArea == area);
            }

            //definir orden de los trabajos
            switch (ordenDef)
            {
                case "Mayor Salario":
                    jobResultList = jobResultList.OrderByDescending(m => m.jobSalary);
                    break;
                case "Menor Salario":
                    jobResultList = jobResultList.OrderBy(m => m.jobSalary);
                    break;
                case "Mas Nuevo":
                    jobResultList = jobResultList.OrderByDescending(m => m.jobPosted);
                    break;
                case "Mas Antiguo":
                    jobResultList = jobResultList.OrderBy(m => m.jobPosted);
                    break;
                default:
                    break;
            }


            List<string> listOrden = new List<string> {"Default", "Mas Antiguo", "Mas Nuevo", "Mayor Salario", "Menor Salario" };

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["jobResultList"] = jobResultList.ToList();
            ViewData["categoriesList"] = categoriesList;
            ViewData["SalaryRange"] = search.salary.ToString();
            ViewData["ExperienceYear"] = search.experience;
            ViewData["Ubication"] = search.ubication;
            ViewData["Type"] = search.type;
            ViewData["Words"] = search.descriptionWords;
            ViewData["orden"] = new SelectList(listOrden, "orden");
            ViewData["area"] = area;
            ViewData["UserName"] = HttpContext.Session.GetString("userName");

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

            List<string> AccountType = new List<string>(new string[] { "Empleado", "Empresa"});

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubication");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;
            ViewData["AccountType"] = new SelectList(AccountType, "Type");

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
