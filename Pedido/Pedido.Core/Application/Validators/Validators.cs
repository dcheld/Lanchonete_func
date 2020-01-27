using Pedido.Core.Application.Ingredients.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Tango.Types;

namespace Pedido.Core.Application
{
    public static class Validators
    {
        public static Option<int> GreatThanZero(int value) =>
              GreatThan(0)(value);

        public static Func<int, Option<int>> GreatThan(int minimum) =>
             value => value > minimum
                 ? Option<int>.Some(value)
                 : Option<int>.None();
    }
}
