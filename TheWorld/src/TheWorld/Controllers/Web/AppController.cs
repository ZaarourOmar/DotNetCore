﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactVM vm)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendEmail(_config["MailSettings:ToAddress"], vm.Email, "Contact", vm.Message);

                ViewBag.UserMessage = "Message sent";
                ModelState.Clear();

            }


            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
