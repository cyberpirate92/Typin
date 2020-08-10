﻿using System.Collections.Generic;
using CliFx.Domain;
using CliFx.Domain.Input;

namespace CliFx.Tests.Internal
{
    internal static class CommandHelper
    {
        public static TCommand ResolveCommand<TCommand>(CommandInput input,
                                                        IReadOnlyDictionary<string, string> environmentVariables)
            where TCommand : ICommand, new()
        {
            var schema = CommandSchema.TryResolve(typeof(TCommand))!;

            var instance = new TCommand();
            schema.Bind(instance, input, environmentVariables);

            return instance;
        }

        public static TCommand ResolveCommand<TCommand>(CommandInput input)
            where TCommand : ICommand, new()
        {
            return ResolveCommand<TCommand>(input, new Dictionary<string, string>());
        }
    }
}