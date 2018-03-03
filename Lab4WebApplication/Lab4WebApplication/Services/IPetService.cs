using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4WebApplication.Models.View;
namespace Lab4WebApplication.Services
{
    public interface IPetService
    {
        PetViewModel GetPet(int id);

        IEnumerable<PetViewModel> GetPetsForUser(string userId);

        void SavePet(string userId, PetViewModel pet);

        void UpdatePet(PetViewModel user);

        void DeletePet(int id);
    }
}