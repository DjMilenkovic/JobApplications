using JobApplications.Models;
using JobApplications.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobApplications.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Candidate> candidateRepository;

        public HomeController(IRepository<Candidate> repository)
        {
            candidateRepository = repository;
        }

        public ActionResult Index()
        {
            var product = candidateRepository.GetData();

            return View(product);
        }
    }
}