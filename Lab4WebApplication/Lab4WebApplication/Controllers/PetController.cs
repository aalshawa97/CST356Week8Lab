﻿using Lab4WebApplication.Data;
using Lab4WebApplication.Data.Entities;
using Lab4WebApplication.Models.View;
using Lab4WebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4WebApplication.Controllers
{
    public class PetController : Controller
    {
        static AppDbContext dbContext;

        EntityRepository entityRepository = new EntityRepository(dbContext);

        public ActionResult List()
        {

            var pets =  GetAllPets();

            return View(pets);
        }

        private IEnumerable<PetViewModel> GetAllPets()
        {

            var petViewModels = new List<PetViewModel>();
            var dbContext = new AppDbContext();

            foreach (var user in dbContext.Pets)
            {
                var petViewModel = MapToPetViewModel(user);

                petViewModels.Add(petViewModel);
            }

            return petViewModels;
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(petViewModel);
                return RedirectToAction("List", new { UserId = petViewModel.UserId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = GetPet(id);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdatePet(petViewModel);

                return RedirectToAction("List",new { userid =  petViewModel.UserId});
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var pet = GetPet(id);

            return View(pet);
        }

        private void UpdatePet(PetViewModel petViewModel)
        {

            var pet = entityRepository.GetPet(petViewModel.Id);

            entityRepository.UpdatePet(pet);
        }

        private void CopyToPet(PetViewModel petViewModel, Pet pet)
        {
            pet.Name = petViewModel.Name;
            pet.Age = petViewModel.Age;
            pet.NextCheckup = petViewModel.NextCheckup;
            pet.VetName = pet.VetName;
        }

        public ActionResult Delete(int id)
        {
            var pet = GetPet(id);

            DeletePet(id);

            return RedirectToAction("List", new { UserId = pet.UserId });
        }

        private PetViewModel GetPet(int petId)
        { 
            var pet = entityRepository.GetPet(petId);

            return MapToPetViewModel(pet);
        }

        private void Save(PetViewModel petViewModel)
        {
            var pet = MapToPet(petViewModel);

            entityRepository.SavePet(pet);
        }

        private void DeletePet(int id)
        {
            entityRepository.DeletePet(id);
        }

        private Pet MapToPet(PetViewModel petViewModel)
        {
            return new Pet
            {
                Id = petViewModel.Id,
                Name = petViewModel.Name,
                Age = petViewModel.Age,
                NextCheckup = petViewModel.NextCheckup,
                VetName = petViewModel.VetName,
            };
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
            return new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                NextCheckup = pet.NextCheckup,
                VetName = pet.VetName,
            };
        }
    }
}
