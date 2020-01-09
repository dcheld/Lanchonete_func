using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace Pedido.API.Extensions
{
    public static class ValidationResultToActionResult
    {
        public static Task<IActionResult> ToActionResult(this Task<Validation<string, int>> self) =>
            self.Map(ToActionResult);

        public static IActionResult ToActionResult(this Validation<string, int> self) =>
           self.Match<IActionResult>(
                Succ: t => new OkObjectResult(t),
                Fail: (e) => new BadRequestResult());
    }
}
