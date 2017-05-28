﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileManager.Models;
using FileManager.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private static Profile _profile;

        public ProfileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        static ProfileController()
        {
            // initialize profile
            _profile = new Profile()
            {
                Name = "Steve Smith",
                AvatarPath = ""
            };
        }
        public IActionResult Index()
        {
            return View(_profile);
        }

        public IActionResult Edit()
        {
            var viewmodel = new ProfileEditViewModel()
            {
                Name = _profile.Name,
                AvatarPath = _profile.AvatarPath
            };
            return View(viewmodel);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ProfileEditViewModel model)
        {
            _profile.Name = model.Name;

            if (model.AvatarFile.Length > 0)
            {
                // don't rely on or trust the FileName property without validation
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.AvatarFile.CopyToAsync(stream);
                    // validate file, then move to CDN or public folder
                }
            }
            _profile.AvatarPath = model.AvatarFile.FileName;

            return RedirectToAction("Index");
        }

    }
}
