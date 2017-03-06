using HogWarsh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh.Repositories
{
    public class HouseRepository
    {
        public void Create(House house)
        {
            using (var context = new Context())
            {
                context.Houses.Add(house);

                context.SaveChanges();
            }
        }
        
        public void Update(House house)
        {
            using (var context = new Context())
            {
                var houseToUpdate = context.Houses.Find(house.Id);
                houseToUpdate.Name = house.Name;
                
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var houseToRemove = context.Houses.Find(id);
                context.Houses.Remove(houseToRemove);

                context.SaveChanges();
            }
        }

        public List<House> GetAll()
        {
            List<House> houses = new List<House>();
            using (var context = new Context())
            {
                houses = context.Houses.ToList();
            }

            return houses;
        }

        public House GetById(int id)
        {
            House house = null;
            using (var context = new Context())
            {
                house = context.Houses.Find(id);
            }

            return house;
        }
    }
}