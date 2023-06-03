using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;

namespace JobSearch_Grupo7.Controllers
{
    public class JobController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;
        public JobController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }

        public IActionResult Job(int jobId=1)
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();
            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            var jobData = (from a in _jobsPortalDbContext.Job
                           join b in _jobsPortalDbContext.JobType on a.jobTypeId equals b.jobTypeId
                           join c in _jobsPortalDbContext.City on a.cityId equals c.cityId
                           join d in _jobsPortalDbContext.Area on a.areaId equals d.areaId
                           where a.jobId == jobId
                           select new
                           { 
                               jobId = a.jobId,
                               jobName = a.jobName, 
                               jobType = b.jobTypePrompt,
                               jobSalary = a.jobSalary,
                               jobExperienceYear = a.jobExperienceYear,
                               jobDescription = a.jobDescription,
                               jobRequirement = a.jobRequirements,
                               jobPosted = a.jobPosted,
                               jobExpiration = a.jobExpiration,
                               jobCity = c.cityName,
                               jobArea = d.areaName,
                               companyId = a.companyId

                           }).ToList();

            int companyId = jobData[0].companyId;


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

            Company companyData = new Company(
                companyDataResult[0].companyId,
                companyDataResult[0].companyName,
                companyDataResult[0].companyDescription,
                companyDataResult[0].compnayDirection,
                companyDataResult[0].companyPhone1,
                companyDataResult[0].companyPhone2,
                companyDataResult[0].companyEmail,
                companyDataResult[0].companyLinkedIn,
                companyDataResult[0].companyPicture);

            var jobComments = (from a in _jobsPortalDbContext.JobComment
                                        join c in _jobsPortalDbContext.Employee on a.employeeId equals c.employeeId
                                        where a.jobId == jobId
                                        select new
                                        {
                                            JobComment = a.jobComment,
                                            EmployeeName = c.employeeName,
                                            EmployeePicture = c.employeePicture,
                                            AnomComment = a.jobCommentAnom,
                                        });

            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;
            ViewData["UserName"] = HttpContext.Session.GetString("userName");
            ViewData["companyData"] = companyData;
            ViewData["jobData"] = jobData;
            ViewData["jobComments"] = jobComments;
            // return View("~/Views/InterfaceObject/Job.cshtml");
            return View();
        }

        public IActionResult SendComment(JobComment jobCommetGet)
        {
            _jobsPortalDbContext.Add(jobCommetGet);
            _jobsPortalDbContext.SaveChanges();
            return RedirectToAction("Job", new { jobId = jobCommetGet.jobId });

        }
    }
}
