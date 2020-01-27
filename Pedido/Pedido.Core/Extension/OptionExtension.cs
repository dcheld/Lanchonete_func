using System;
using System.Collections.Generic;
using System.Text;
using Tango.Types;

namespace Pedido.Core.Extension
{
    public static class OptionExtension
    {
        public static Either<T2, T> ToEither<T, T2>(this Option<T> option, T2 left) =>
            option.Match<Either<T2, T>>(
                v => v,
                () =>left
            );
    }
}
