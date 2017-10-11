using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dz.SoftwareRequest.Models;
using dz.SoftwareRequest.ViewModels;

namespace dz.SoftwareRequest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
                // var requests = GetRequestBy("kasem");
                // return View(requests);;
                return RedirectToAction("Register","Account");
        }

        public static IEnumerable<RequestViewModel> GetRequestBy(string requestBy)
        {
            DevelopTask development = new DevelopTask {ActionBy = "Kasem", StartDate = DateTime.Now,FinishDate = DateTime.Now,Remark = "Remark bay programmmer"};

            var requests = new List<RequestViewModel>
            {
                new RequestViewModel {DocNo = "2017/0001",RequestBy= "Puchit.c",Title="Request Software A",Description = "1.aa 2.bb 3.cc",RequestDate = DateTime.Today,ApprovedBy="Prajin.t"},
                new RequestViewModel {DocNo = "2017/0002",RequestBy= "Benjawan.c",Title="Request Software B", Description = "1.cc 3.cc 4.dd",RequestDate = DateTime.Today,ApprovedBy="Prajin.t"},
                new RequestViewModel {DocNo = "2017/0003",RequestBy= ".c",Title="Update Software C",Description="Add genereate small barcode",RequestDate = DateTime.Today},
            };

            return requests.ToList();
        }

        [HttpGet]
        public IActionResult RequestNew()
        {
            var request = new RequestViewModel();
            request.DocNo = "2017/0001";
            request.RequestBy = "Puchit.c";
            return View(request);
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
