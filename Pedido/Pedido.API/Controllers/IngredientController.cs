using Microsoft.AspNetCore.Mvc;
using Pedido.Core.Application.Ingredients.Commands;
using Pedido.Core.Application.Ingredients.Queries;
using System.Threading.Tasks;

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IGetIngredientAllHandler _getIngredientAllHandler;
        private readonly IGetIngredientByIdHandler _ingredianteQueryHandler;
        private readonly IDeleteIngredientHandler _deleteIngredientHandler;
        private readonly ICreateIngredientHandler _createIngredientHandler;
        private readonly IUpdateIngredientHandler _updateIngredientHandler;

        public IngredientController(IGetIngredientByIdHandler ingredianteQueryHandler,
            IGetIngredientAllHandler getIngredientAllHandler,
            IDeleteIngredientHandler deleteIngredientHandler,
            ICreateIngredientHandler createIngredientHandler,
            IUpdateIngredientHandler updateIngredientHandler)
        {
            _ingredianteQueryHandler =ingredianteQueryHandler;
            _getIngredientAllHandler = getIngredientAllHandler;
            _deleteIngredientHandler = deleteIngredientHandler;
            _createIngredientHandler = createIngredientHandler;
            _updateIngredientHandler = updateIngredientHandler;
        }

        [HttpGet()]
        public async Task<IActionResult> Get() =>
            Ok(await _getIngredientAllHandler.Handle());

        [HttpGet("{ingredientId}")]
        public async Task<IActionResult> GetById(int ingredientId) =>
            (await _ingredianteQueryHandler.Handle(new GetIngredientById(ingredientId)))
                .Match<IActionResult>(
                    result => Ok(result),
                    erro => BadRequest(erro));

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredient createIngredient) =>
           (await _createIngredientHandler.Handle(createIngredient))
                .Match<IActionResult>(
                    result => Ok(result),
                    erro => BadRequest(erro));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateIngredient updateIngredient) =>
           (await _updateIngredientHandler.Handle(updateIngredient))
                .Match<IActionResult>(
                    result => Ok(),
                    erro => BadRequest(erro));

        [HttpDelete("{ingredientId}")]
        public async Task<IActionResult> Delete(int ingredientId) =>
            (await _deleteIngredientHandler.Handle(new DeleteIngredient(ingredientId)))
                .Match<IActionResult>(
                    result => Ok(),
                    erro => BadRequest(erro));
    }
}