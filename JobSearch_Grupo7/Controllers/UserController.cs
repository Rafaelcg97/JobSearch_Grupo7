using Azure.Identity;
using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace JobSearch_Grupo7.Controllers
{
    public class UserController : Controller
    {
        private readonly JobsPortalDbContext _jobsPortalDbContext;
        public UserController(JobsPortalDbContext jobsPortalDbContext)
        {
            _jobsPortalDbContext = jobsPortalDbContext;
        }
        public IActionResult LogIn(User user)
        {

            var userLogging = (from m in _jobsPortalDbContext.User
                              where m.emailUser == user.emailUser && m.passwordUser == user.passwordUser
                              select new { m.idUser, m.emailUser}
                              ).ToList();

            if (userLogging.Count()>0) 
            {
                int idUser = userLogging[0].idUser;
                string userName = userLogging[0].emailUser;
                HttpContext.Session.SetString("userName", userName);

                byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                               where m.objectName == "logo"
                               select m.objectContentImage).First();

                var bannerInicial = (from m in _jobsPortalDbContext.InterfaceObject
                                     where m.objectName == "banner"
                                     select new { m.objectContentImage, m.objectContentText }).First();

                List<byte[]> companyPictures = (from m in _jobsPortalDbContext.Company
                                                select m.companyPicture).Take(10).ToList();

                var citiesList = (from m in _jobsPortalDbContext.City
                                  select m.cityName).ToList();

                var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

                int countCompanies = _jobsPortalDbContext.Company.Count();
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
                ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
                ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
                ViewData["SalaryRange"] = 1500;
                ViewData["ExperienceYear"] = 5;
                ViewData["UserName"] = HttpContext.Session.GetString("userName");

                return View("~/Views/InterfaceObject/Index.cshtml");
            }
            else
            {
                byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                               where m.objectName == "logo"
                               select m.objectContentImage).First();

                var bannerInicial = (from m in _jobsPortalDbContext.InterfaceObject
                                     where m.objectName == "banner"
                                     select new { m.objectContentImage, m.objectContentText }).First();

                List<byte[]> companyPictures = (from m in _jobsPortalDbContext.Company
                                                select m.companyPicture).Take(10).ToList();

                var citiesList = (from m in _jobsPortalDbContext.City
                                  select m.cityName).ToList();

                var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

                byte[] banner = bannerInicial.objectContentImage;
                string bannerText = bannerInicial.objectContentText;

                ViewData["logoImage"] = logo;
                ViewData["bannerImage"] = banner;
                ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
                ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
                ViewData["SalaryRange"] = 1500;
                ViewData["ExperienceYear"] = 5;
                ViewData["UsuarioErroneo"] = "Credenciales Invalidas";

                return View("~/Views/InterfaceObject/SignIn.cshtml");
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userName");
            byte[] logo = (from m in _jobsPortalDbContext.InterfaceObject
                           where m.objectName == "logo"
                           select m.objectContentImage).First();

            var bannerInicial = (from m in _jobsPortalDbContext.InterfaceObject
                                 where m.objectName == "banner"
                                 select new { m.objectContentImage, m.objectContentText }).First();

            List<byte[]> companyPictures = (from m in _jobsPortalDbContext.Company
                                            select m.companyPicture).Take(10).ToList();

            var citiesList = (from m in _jobsPortalDbContext.City
                              select m.cityName).ToList();

            var jobTypesList = (from m in _jobsPortalDbContext.JobType select m.jobTypePrompt).ToList();

            int countCompanies = _jobsPortalDbContext.Company.Count();
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
            ViewData["citiesList"] = new SelectList(citiesList, "ubicacion");
            ViewData["jobTypesList"] = new SelectList(jobTypesList, "type");
            ViewData["SalaryRange"] = 1500;
            ViewData["ExperienceYear"] = 5;
            ViewData["UserName"] = HttpContext.Session.GetString("userName");

            return View("~/Views/InterfaceObject/Index.cshtml");
        }

        public IActionResult signUp(string name, string description, string email, string phone, string password) 
        {



            return View("~/Views/InterfaceObject/Index.cshtml");
        }
    }
}
