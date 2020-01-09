using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.API.Extensions
{
    public static class EitherToActionResult
    {
        public static Task<IActionResult> ToActionResult<L, R>(this Task<Either<L, R>> either) =>
            either.Map(Match);

        private static IActionResult Match<L, R>(this Either<L, R> either) =>
            either.Match<IActionResult>(
                Left: l => new BadRequestObjectResult(l),
                Right: r => new OkObjectResult(r));
    }
}
