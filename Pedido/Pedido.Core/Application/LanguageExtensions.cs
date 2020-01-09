using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Core.Application
{
    public static class LanguageExtensions
    {
        public static Either<string, R> ToEither<R>(this Validation<string, R> validation) =>
             validation.ToEither().MapLeft(errors => errors.Join());

        public static Task<Either<string, R>> ToEither<R>(this Task<Validation<string, R>> validation) =>
            validation.Map(v => v.ToEither<R>());

        public static Task<Either<string, R>> ToEitherAsync<R>(this Validation<string, Task<R>> validation) =>
            validation.ToEither()
                .MapLeft(errors => errors.Join())
                .MapAsync<string, Task<R>, R>(e => e);

        public static string Join(this Seq<string> errors) => string.Join("; ", errors);
    }
}
