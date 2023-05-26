using JobSearch_Grupo7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var myImage = (from m in _jobsPortalDbContext.InterfaceObject where m.objectName == "logo" select m.objectContentImage).ToString();
  
            ViewData["listInterfaceElements"] = myImage;
            return View();
        }
    }
}
