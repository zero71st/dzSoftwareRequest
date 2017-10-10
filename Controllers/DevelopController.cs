using Microsoft.AspNetCore.Mvc;
using System;

namespace dz.SoftwareRequest.Controllers
{
    public class DevelopController:Controller
    {
        public IActionResult Update(int Id)
        {
            var request = RequestController.GetRequestBy(Id);
            
            return View(request);
        }
    }
}