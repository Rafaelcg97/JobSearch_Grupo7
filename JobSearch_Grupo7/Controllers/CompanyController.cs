using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;

namespace JobSearch_Grupo7.Controllers
{
    public class CompanyController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;

        public CompanyController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }

        public IActionResult Company(int companyId=0)
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();
            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            var companyDataResult = (from a in _jobsPortalDbContext.Company
                                 where a.companyId == companyId
                                 select new
                                 {
                                     companyId = a.companyId,
                                     companyName = a.companyName,
                                     companyDescription = a.companyDescription,
                                     compnayDirection=a.companyDirection,
                                     companyPhone1 = a.companyPhone1,
                                     companyPhone2=a.companyPhone2,
                                     companyEmail=a.companyEmail,
                                     companyLinkedIn=a.companyLinkedIn,
                                     companyPicture = a.companyPicture
                                 }).ToList();

            Company companyData = new Company(companyDataResult[0].companyId, companyDataResult[0].companyName, companyDataResult[0].companyDescription, companyDataResult[0].compnayDirection, companyDataResult[0].companyPhone1, companyDataResult[0].companyPhone2, companyDataResult[0].companyEmail, companyDataResult[0].companyLinkedIn, companyDataResult[0].companyPicture);

            var jobResultList = (from a in _jobsPortalDbContext.Job
                                 join c in _jobsPortalDbContext.City on a.cityId equals c.cityId
                                 join e in _jobsPortalDbContext.Area on a.areaId equals e.areaId
                                 where a.companyId == companyId
                                 select new
                                 {
                                     jobName = a.jobName,
                                     jobCity = c.cityName,
                                     jobSalary = a.jobSalary,
                                     jobId = a.jobId
                                 });

            int countJobsPerCompany = (from m in _jobsPortalDbContext.Job where m.companyId == companyId select m).Count();

            int countApplicationsPerCompany = (from a in _jobsPortalDbContext.Application
                                               join b in _jobsPortalDbContext.Job on a.jobId equals b.jobId
                                               join c in _jobsPortalDbContext.Company on b.companyId equals c.companyId
                                               where c.companyId == companyId select a.applicationId).Count();

            var companyOpinionResult = (from a in _jobsPortalDbContext.companyOpinion
                                 join c in _jobsPortalDbContext.Employee on a.employeeId equals c.employeeId
                                 where a.companyId == companyId
                                 select new
                                 {
                                     CompanyOpinion = a.companyOpinion,
                                     EmployeeName =c.employeeName,
                                     EmployeePicture =c.employeePicture,
                                     AnomComment =a.companyOpinionAnom,
                                 });

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["companyData"] = companyData;
            ViewData["jobPerCompany"] = jobResultList.ToList();
            ViewData["countJobsPerCompany"] = countJobsPerCompany;
            ViewData["countApplicationsPerCompany"] = countApplicationsPerCompany;
            ViewData["companyOpinionResult"] = companyOpinionResult.ToList();
            ViewData["TotalCommentsCount"] = companyOpinionResult.Count();
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;
            ViewData["UserName"] = HttpContext.Session.GetString("userName");
            return View();
        }

        public IActionResult SendComment(CompanyOpinion companyOpinionGet)
        {
            _jobsPortalDbContext.Add(companyOpinionGet);
            _jobsPortalDbContext.SaveChanges();
            return RedirectToAction("Company", new { companyId = companyOpinionGet.companyId });

        }
        public IActionResult Details( int companyId)
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();
            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            var companyDataResult = (from a in _jobsPortalDbContext.Company
                                     where a.companyId == companyId
                                     select new
                                     {
                                         companyId = a.companyId,
                                         companyName = a.companyName,
                                         companyDescription = a.companyDescription,
                                         compnayDirection = a.companyDirection,
                                         companyPhone1 = a.companyPhone1,
                                         companyPhone2 = a.companyPhone2,
                                         companyEmail = a.companyEmail,
                                         companyLinkedIn = a.companyLinkedIn,
                                         companyPicture = a.companyPicture
                                     }).ToList();

            Company companyData = new Company(companyDataResult[0].companyId, companyDataResult[0].companyName, companyDataResult[0].companyDescription, companyDataResult[0].compnayDirection, companyDataResult[0].companyPhone1, companyDataResult[0].companyPhone2, companyDataResult[0].companyEmail, companyDataResult[0].companyLinkedIn, companyDataResult[0].companyPicture);




            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["companyData"] = companyData;
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;



            return View("~/Views/Company/Job_details.cshtml");
        }

        public IActionResult SendJob(Job newJob)
        {
            _jobsPortalDbContext.Add(newJob);
            _jobsPortalDbContext.SaveChanges();//Aqui hay error por alguna razon no puedo captar los datos 
            return View("~/Views/Company/Job_details.cshtml");

        }

    }
}
