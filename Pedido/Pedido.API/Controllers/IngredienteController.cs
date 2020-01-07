using Microsoft.AspNetCore.Mvc;
using Pedido.Core.Application.Ingredientes.Commands;
using System.Collections.Generic;

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : Controller
    {

        public IngredienteController()
        {
        }

        [HttpGet]
        public IEnumerable<CreateIngrediente> Get()
        {
            return new List<CreateIngrediente>();
        }

        [HttpPost]
        public void Create(CreateIngrediente ingrediente)
        {
        }

        [HttpPut]
        public void Update(CreateIngrediente ingrediente)
        {
        }

        [HttpDelete]
        public void Delete(CreateIngrediente ingrediente)
        {
        }
    }
}