using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobSearch_Grupo7.Controllers
{
    public class CompanyController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;

        public CompanyController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }

        //[Route("/company/company")]
        public IActionResult Company(int companyId=0)
        {
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();
            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            var jobResultList = (from a in _jobsPortalDbContext.Company
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

            Company companyData = new Company(jobResultList[0].companyId, jobResultList[0].companyName, jobResultList[0].companyDescription, jobResultList[0].compnayDirection, jobResultList[0].companyPhone1, jobResultList[0].companyPhone2, jobResultList[0].companyEmail, jobResultList[0].companyLinkedIn, jobResultList[0].companyPicture);
            ViewData["logoImage"] = logo;
            ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["companyData"] = companyData;
            return View();
        }
    }
}
