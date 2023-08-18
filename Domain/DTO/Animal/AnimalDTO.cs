using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Animal
{
    public class AnimalDTO
    {
        public int Animalid { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
    }
}
