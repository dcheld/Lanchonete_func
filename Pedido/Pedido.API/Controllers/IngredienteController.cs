using Microsoft.AspNetCore.Mvc;
using Pedido.API.Extensions;
using Pedido.Core.Application.Ingredientes.Commands;
using Pedido.Core.Data.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : Controller
    {
        private readonly IMediator mediator;

        public IngredienteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<CreateIngrediente> Get()
        {
            return new List<CreateIngrediente>();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngrediente createIngrediente) =>
                await mediator.SendAsync(createIngrediente)
                    .ToActionResult();

        [HttpDelete]
        public void Delete(CreateIngrediente ingrediente)
        {
        }
    }
}