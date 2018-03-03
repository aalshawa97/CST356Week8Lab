using System;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using Lab4WebApplication.Models.View;
using Lab4WebApplication.Services;

namespace Lab4WebApplication.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly ILog _log = LogManager.GetLogger(typeof(PetController));

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            _log.Debug("Getting list of pets for user: " + userId);

            var petViewModels = _petService.GetPetsForUser(userId);

            return View(petViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            _log.Info("Creating pet");

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _petService.SavePet(userId, petViewModel);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to save pet.", ex);
                throw;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = _petService.GetPet(id);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _petService.UpdatePet(petViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var pet = _petService.GetPet(id);

            return View(pet);
        }

        public ActionResult Delete(int id)
        {
            _petService.DeletePet(id);

            return RedirectToAction("List");
        }
    }
}