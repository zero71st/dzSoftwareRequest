using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dz.SoftwareRequest.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace dz.SoftwareRequest.Controllers
{
    public class DevelopController:Controller
    {
        private readonly ApplicationContext _db;
        public DevelopController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Update(int Id)
        {
            var model = _db.Requests.FirstOrDefault(r=> r.Id == Id);
            
            return View(model);
        }
    }
}