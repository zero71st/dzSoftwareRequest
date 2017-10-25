using System;
using System.Collections.Generic;
using System.Linq;
using dz.SoftwareRequest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using dz.SoftwareRequest.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using dz.SoftwareRequest.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace dz.SoftwareRequest.Controllers
{
    public class RequestController:Controller
    {
        private readonly ApplicationContext _db;
        public  RequestController(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var requests = await GetAllRequestAsync();

            var model =  requests.Select(r=> new RequestViewModel{
                Id = r.Id,
                DocNo = r.DocNo,
                Title = r.Title,
                Description = r.Description,
                RequestBy = r.RequestBy.ActionBy
            });

            return View(model);;
        }

        private async Task<IEnumerable<Request>> GetAllRequestAsync()
        {
            return await _db.Requests
                        .Include("RequestBy")
                        .ToListAsync();
        }

        private string GetNextDocNo()
        {
            var request = _db.Requests.OrderByDescending(r=> r.Id).FirstOrDefault();
            string prefix = request.DocNo.Substring(0,5);
            int no = int.Parse(request.DocNo.Substring(5,4));
            return prefix+(no+1).ToString("0000");
        }

        private Request GetRequestById(int id)
        {
            var request = _db.Requests
                      .Include("RequestBy")
                      .FirstOrDefault(r=> r.Id == id);
            return request;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new RequestViewModel();
            model.DocNo = GetNextDocNo();
            model.RequestDate = DateTime.Now;
            model.RequestBy = User.Identity.Name;

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create([Bind("DocNo,Title,Description,RequestBy")] RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new Request
                    (
                        model.DocNo,
                        model.Title,
                        model.Description,
                        new ActionRole
                        {
                            ActionBy = User.Identity.Name,
                            ActionDate =  DateTime.Now
                        }
                    );
                    CreateRequestAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(model);
        }

        private async void CreateRequestAsync(Request request)
        {
            await _db.Requests.AddAsync(request);
            await _db.SaveChangesAsync();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var request = GetRequestById(id);

            var model = new RequestViewModel
            {
                Id = request.Id,
                DocNo = request.DocNo,
                RequestBy = request.RequestBy.ActionBy,
                RequestDate = request.RequestBy.ActionDate,
                Title = request.Title,
                Description = request.Description,
                ApprovedBy = request.ApproveBy != null ? request.ApproveBy.ActionBy : ""
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id,[Bind("Id,DocNo,Title,Description")] RequestViewModel model)
        {        
            var request = GetRequestById(id);
            if (request == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                   request.Title = model.Title;
                   request.Description = model.Description;      
                   _db.Update(request);
                   _db.SaveChanges();

                   return RedirectToAction("Index","Request");

                }catch (DbUpdateException e)
                {
                    ModelState.AddModelError("",e.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Approve(int id)
        {
            var request = GetRequestById(id);
            var model = new RequestViewModel();
            model.Id = request.Id;
            model.DocNo = request.DocNo;
            model.Title = request.Title;
            model.Description = request.Description;
            model.RequestBy = request.RequestBy.ActionBy;
            model.RequestDate = request.RequestBy.ActionDate;

            return View(model);
        }

        [HttpPost]
        public IActionResult Approve(int id,RequestViewModel model)
        {
            
            try
            {
                var request = GetRequestById(id);
                request.Approve(User.Identity.Name);
                _db.Update(request);
                _db.SaveChanges();
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError("",e.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}