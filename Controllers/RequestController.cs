using System;
using System.Collections.Generic;
using System.Linq;
using dz.SoftwareRequest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dz.SoftwareRequest.Controllers
{
    public class RequestController:Controller
    {
        public IActionResult Index()
        {
            var requests = GetRequestBy("kasem");
            return View(requests);;
        }

        private IEnumerable<RequestViewModel> GetRequestBy(string requestBy)
        {
            var requests = new List<RequestViewModel>
            {
                new RequestViewModel {DocNo = "2017/0001",RequestBy= "Puchit.c",Title="Request Software A",Description = "1.aa 2.bb 3.cc",RequestDate = DateTime.Today,ApprovedRequestBy="Prajin.t"},
                new RequestViewModel {DocNo = "2017/0002",RequestBy= "Benjawan.c",Title="Request Software B", Description = "1.cc 3.cc 4.dd",RequestDate = DateTime.Today,ApprovedRequestBy="Prajin.t"},
                new RequestViewModel {DocNo = "2017/0003",RequestBy= ".c",Title="Update Software C",Description="Add genereate small barcode",RequestDate = DateTime.Today},
            };

            return requests.ToList();
        }

        [HttpPost]
        public IActionResult Create()
        {
            var request = new RequestViewModel();
            request.DocNo = "2017/0001";
            request.RequestDate = DateTime.Now;
            request.RequestBy = "Puchit.c";
            return View(request);     
        }

        [HttpGet]
        public IActionResult Update()
        {
            var requests = GetRequestBy("Kasem");

            var request = requests.FirstOrDefault();
            request.DocNo = "2017/0001";
            request.RequestDate = DateTime.Now;
            request.RequestBy = "Puchit.c";
            return View(request);     
        }
    }
}