using Domain.DTO.Animal;
using Domain.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IAnimalesService
    {
        public bool AddAnimal(AnimalDTO animal);
        public bool UpdateAnimal(AnimalDTO animal);
        public bool DeleteAnimal(int id);
        public AnimalDTO GetAnimal(int id);
        public bool CreateOrder(OrderResult dto);
    }
}
