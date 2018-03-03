using Lab4WebApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4WebApplication.Repositories
{
    public interface IPetRepository
    {
        Pet GetPet(int id);

        IEnumerable<Pet> GetPetsForUser(string userId);

        void SavePet(Pet pet);

        void UpdatePet(Pet user);

        void DeletePet(int id);
    }
}