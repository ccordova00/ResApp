using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResApp.Data;
using ResApp.Models;

namespace ResApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ResAppContext _context;

        public HomeController(ResAppContext context)
        {
            _context = context;
        }

        //Get: Index
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            
            var applicant = _context.Applicant
                .Include(y => y.Certs)
                .Include(y => y.Jobs)
                    .ThenInclude(y => y.Responsibilities)
                .Include(y => y.Educations)
                .Include(y => y.Skills)
                    .ThenInclude(y => y.Category)
                .Include(y => y.References)
                .Include(y => y.Links)
                    
                .AsNoTracking()
                .Where(y => y.LastName == "Cordova")
                .First();

            return View(applicant);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
