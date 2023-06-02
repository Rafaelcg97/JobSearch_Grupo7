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

        public IActionResult Job()
        {
            return View("~/Views/InterfaceObject/Job.cshtml");
        }
    }
}
