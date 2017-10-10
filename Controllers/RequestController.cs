using System;
using System.Collections.Generic;
using System.Linq;
using dz.SoftwareRequest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using dz.SoftwareRequest.Models;

namespace dz.SoftwareRequest.Controllers
{
    public class RequestController:Controller
    {
        public IActionResult Index()
        {
            var requests = GetRequestBy("kasem");
            return View(requests);;
        }

        public static IEnumerable<RequestViewModel> GetRequestBy(string requestBy)
        {
             DevelopTask development = new DevelopTask {ActionBy = "Kasem", StartDate = DateTime.Now,FinishDate = DateTime.Now,Remark = "Remark bay programmmer",AttrachFile=@"\dzdata\xxx.pff"};
             DevelopTask review = new DevelopTask {ActionBy = "Jakkapan", StartDate = DateTime.Now,FinishDate = DateTime.Now,Remark = "Remark bay programmmer",AttrachFile=@"\dzdata\xxx.pff"};
             DevelopTask uat = new DevelopTask {ActionBy = "Puchit.c", StartDate = DateTime.Now,FinishDate = DateTime.Now,Remark = "Remark bay programmmer",AttrachFile=@"\dzdata\xxx.pff"};
             DevelopTask security = new DevelopTask {ActionBy = "Puchit.c", StartDate = DateTime.Now,FinishDate = DateTime.Now,Remark = "Remark bay programmmer",AttrachFile=@"\dzdata\xxx.pff"};
            
            var requests = new List<RequestViewModel>
            {
                new RequestViewModel {Id=1,DocNo = "2017/0001",Development = development,CodeReview = review,Security=security,UAT = uat,RequestBy= "Puchit.c",Title="Request Software A",Description = "1.aa 2.bb 3.cc",RequestDate = DateTime.Today,ApprovedBy="Prajin.t"},
                new RequestViewModel {Id=2,DocNo = "2017/0002",Development = development,CodeReview = review,Security=security,UAT = uat,RequestBy= "Benjawan.c",Title="Request Software B", Description = "1.cc 3.cc 4.dd",RequestDate = DateTime.Today,ApprovedBy="Prajin.t"},
                new RequestViewModel {Id=3,DocNo = "2017/0003",Development = development,CodeReview = review,Security=security,UAT = uat,RequestBy= ".c",Title="Update Software C",Description="Add genereate small barcode",RequestDate = DateTime.Today},
            };

            return requests.ToList();
        }

        public static RequestViewModel GetRequestBy(int Id)
        {
            var requests = GetRequestBy("Kasem");
            var request = requests.FirstOrDefault(r=> r.Id==Id);
            return request;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var request = new RequestViewModel();
            request.DocNo = "2017/0001";
            request.RequestDate = DateTime.Now;
            request.RequestBy = "Puchit.c";
            return View(request);     
        }
        
        [HttpPost]
        public IActionResult Create([Bind("DocNo,Title,Description")] RequestViewModel request)
        {
           return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var request = GetRequestBy(id);
            request.DocNo = "2017/0001";
            request.RequestDate = DateTime.Now;
            request.RequestBy = "Puchit.c";
            return View(request);
        }

        [HttpGet]
        public IActionResult Approve(int id)
        {
            var request = GetRequestBy(id);
            return View(request);
        }
    }
}