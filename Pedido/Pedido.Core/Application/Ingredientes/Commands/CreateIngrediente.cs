using LanguageExt;
using Pedido.Core.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class CreateIngrediente : ICommand<CreateIngrediente, Either<string, int>>
    {
        public string Name { get; }

        public CreateIngrediente(string name)
        {
            Name = name;
        }
    }
}
