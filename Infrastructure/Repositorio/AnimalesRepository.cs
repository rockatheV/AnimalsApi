using Domain.DTO.Animal;
using Domain.DTO.Order;
using Infrastructure.Data;
using Infrastructure.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorio
{
    public class AnimalesRepository : IAnimalesRepository
    {
        ANIMALESContext _c;
        public AnimalesRepository(ANIMALESContext c)
        {
            _c = c;
        }
        public bool AddAnimal(AnimalDTO animal)
        {
            Animale obj = new Animale();
            
                obj.Animalid = animal.Animalid;
                obj.Birthdate = animal.Birthdate;
                obj.Breed = animal.Breed;
                obj.Name = animal.Name;
                obj.Price = animal.Price;
                obj.Sex = animal.Sex;
                obj.Status = animal.Status;
            
            try
            {
                _c.Animales.Add(obj);
                var rows = _c.SaveChanges();
                bool result = (rows > 0);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateOrder(OrderResult dto)
        {
            Orden obj = new Orden();

            obj.Id = dto.Id;
            obj.Total = dto.MontoTotal;

            try
            {
                _c.Ordens.Add(obj);
                var rows = _c.SaveChanges();
                bool result = (rows > 0);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAnimal(int animal)
        {
            try
            {
                var todelete = _c.Animales.First(e =>e.Animalid == animal);
                if (todelete != null)
                {
                    _c.Animales.Remove(todelete);
                }else{
                    return false;
                }
                var rows = _c.SaveChanges();
                bool result = (rows > 0);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AnimalDTO GetAnimal(int id)
        {
            
            try
            {
                var result = _c.Animales.First(e => e.Animalid == id);
                AnimalDTO obj = new AnimalDTO
                {
                    Animalid = result.Animalid,
                    Birthdate = result.Birthdate,
                    Breed = result.Breed,
                    Name = result.Name,
                    Price = result.Price,
                    Sex = result.Sex,
                    Status = result.Status
                };
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateAnimal(AnimalDTO animal)
        {
            Animale obj = new Animale
            {
                Animalid = animal.Animalid,
                Birthdate = animal.Birthdate,
                Breed = animal.Breed,
                Name = animal.Name,
                Price = animal.Price,
                Sex = animal.Sex,
                Status = animal.Status,
            };
            try
            {
                _c.Animales.Add(obj);
                var rows = _c.SaveChanges();
                bool result = (rows > 0);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
