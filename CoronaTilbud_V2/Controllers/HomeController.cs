using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaTilbud_V2.Models;
using CoronaTilbud_V2.ViewModels;
using CoronaTilbud_V2.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace CoronaTilbud_V2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService emailService;

        public HomeController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {

            var emailFormViewModel = new EmailFormViewModel();

            return View(emailFormViewModel);
        }

        [HttpPost]
        public IActionResult Contact(EmailFormViewModel emailFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(emailFormViewModel);
            }
            var emailForm = new EmailForm
            {
                Email = emailFormViewModel.EmailForm.Email,
                Message = emailFormViewModel.EmailForm.Message,
                Name = emailFormViewModel.EmailForm.Name,
                Phone = emailFormViewModel.EmailForm.Phone,
                Subject = emailFormViewModel.EmailSubjectSelected

            };

            if (emailForm.Subject == "Valg")
            {
                ViewData["Selected"] = "du skal valg ";
            }
            else
            {
                emailService.Send(emailForm);
                return View("ContactOk", emailFormViewModel);

            }
            return View(emailFormViewModel);

        }



        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Goods()
        {
            return View();
        }
        public IActionResult CreateAdd()
        {
            var addFormViewModel = new AddFormViewModel();
            return View(addFormViewModel);
        }

        [HttpPost]
        public IActionResult CreateAdd(AddFormViewModel addFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("addFormViewModel");
            }

            var key = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

            //for (int i = 0; i < key.Count; i++)
            //{

            //}

            //var pic = key.ElementAt(6).Value;

            //var files = Request.Form.Keys.Any() ? Request.Form.Files : new FormFileCollection();
            


            //var myAttachment = new Attachment(addFormViewModel.AddForm.Attachment.FileName, addFormViewModel.AddForm.Attachment);
            var addForm = new AddForm
            {
                CompanyName = addFormViewModel.AddForm.CompanyName,
                Email = addFormViewModel.AddForm.Email,
                Headline = addFormViewModel.AddForm.Headline,
                Message = addFormViewModel.AddForm.Message,
                Phone = addFormViewModel.AddForm.Phone,
                Subject = addFormViewModel.SelectedSubject,
                Attachments = addFormViewModel.AddForm.Attachments
            };
       
                emailService.SendAdd(addForm);
                return View("AddFormOk", addFormViewModel);
           
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
