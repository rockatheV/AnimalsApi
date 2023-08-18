using Domain.DTO.Animal;
using Domain.DTO.Order;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace AnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalesService _service;
        public AnimalsController(IAnimalesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAnimal/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimalDTO))]
        public async Task<IResult> GetAnimal(int id)
        {

            var result = _service.GetAnimal(id);
            return result == null ? Results.NoContent() : Results.Ok(result);

        }
        [HttpPost]
        [Authorize]
        [Route("InsertAnimal")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IResult> InsertAnimal(AnimalDTO animal)
        {

            var result = _service.AddAnimal(animal);
            return result == null ? Results.NoContent() : Results.Ok(result);

        }
        [HttpPut]
        [Route("UpdateAnimal")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IResult> UpdateAnimal(AnimalDTO animal)
        {

            var result = _service.UpdateAnimal(animal);
            return result == null ? Results.NoContent() : Results.Ok(result);

        }
        [HttpDelete]
        [Route("DeleteAnimal")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IResult> DeleteAnimal(int animal)
        {

            var result = _service.DeleteAnimal(animal);
            return result == null ? Results.NoContent() : Results.Ok(result);

        }

        [HttpPost]
        [Route("Order")]
        [Authorize]
        public async Task<IResult> CreateOrder(List<AnimalDTO> animales)
        {
            var duplicados = new HashSet<int>();
            var noDuplicados = new List<AnimalDTO>();

            foreach (var animal in animales)
            {
                if (duplicados.Contains(animal.Animalid))
                {
                    return Results.BadRequest($"Animales Duplicados { animal.Name}");
                }

                duplicados.Add(animal.Animalid);
                noDuplicados.Add(animal);
            }

            // Calcular descuentos y total
            double total = 0;
            foreach (var animal in noDuplicados)
            {
                double precio = animal.Price;

                if (animal.Quantity > 50)
                {
                    precio *= 0.95; // 5% de descuento
                }

                total += precio * animal.Quantity;
            }

            double descuentoAdicional = total > 200 ? total * 0.03 : 0;

            // Aplicar descuento adicional
            total -= descuentoAdicional;

            // Calcular flete
            double flete = total > 300 ? 0 : 1000;

            // Calcular total final
            total += flete;

            var ordenCompra = new OrderResult
            {
                Id = Guid.NewGuid(),
                MontoTotal = total
            };
            _service.CreateOrder(ordenCompra);
            return Results.Ok(ordenCompra);
        }
    }
}
