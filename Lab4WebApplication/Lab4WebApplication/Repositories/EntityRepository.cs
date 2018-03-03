using Lab4WebApplication.Data;
using Lab4WebApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4WebApplication.Repositories
{
    public interface IEntity
    {
        Pet GetPet(int id);

        void SavePet(Pet pet);

        void UpdatePet(Pet user);

        void DeletePet(int id);
    }

    public class EntityRepository:IEntity
    {
        public EntityRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext = new AppDbContext();
        }

        AppDbContext dbContext;

        public Pet GetPet(int id)
        {
            return dbContext.Pets.Find(id);
        }

        public void SavePet(Pet pet)
        {
            dbContext.Pets.Add(pet);

            dbContext.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            dbContext.SaveChanges();
        }

        public void DeletePet(int id)
        {
            var pet = dbContext.Pets.Find(id);

            if (pet == null) return;

            dbContext.Pets.Remove(pet);
            dbContext.SaveChanges();
        }

    }
}