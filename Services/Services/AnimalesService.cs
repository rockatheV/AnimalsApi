using Domain.DTO.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositorio.Interfaces;
using Services.Services.Interfaces;
using Domain.DTO.Order;
using Infrastructure.Data;

namespace Services.Services
{
    public class AnimalesService : IAnimalesService
    {
        private readonly IAnimalesRepository _repo;
        public AnimalesService(IAnimalesRepository repo)
        {

            _repo = repo;

        }
        public bool AddAnimal(AnimalDTO animal)
        {
            try
            {
                var result = _repo.AddAnimal(animal);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateOrder(OrderResult dto)
        {
            try
            {
                var result = _repo.CreateOrder(dto);
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
                var result = _repo.DeleteAnimal(animal);
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
                var result = _repo.GetAnimal(id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateAnimal(AnimalDTO animal)
        {
            try
            {
                var result = _repo.UpdateAnimal(animal);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
