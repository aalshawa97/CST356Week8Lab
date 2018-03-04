using Lab4WebApplication.Data.Entities;
using System.Collections.Generic;

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