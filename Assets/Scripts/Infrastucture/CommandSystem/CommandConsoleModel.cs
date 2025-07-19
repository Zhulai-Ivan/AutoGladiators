using System;

namespace Infrastucture.CommandSystem
{
    public class CommandConsoleModel
    {
        private readonly CommandRegistry _registry;

        public CommandConsoleModel(CommandRegistry registry)
        {   
            _registry = registry;
        }

        public string ExecuteCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Empty command.";

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return "Invalid command.";

            string commandName = parts[0];
            string[] args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

            if (_registry.TryGetCommand(commandName, out var command, out var target))
            {
                var parameters = command.GetParameters();
                if (parameters.Length != args.Length)
                    return $"Wrong number of arguments. Expected {args.Length} arguments but found {parameters.Length}.";
                
                object[] convertedArgs = new object[parameters.Length];

                try
                {
                    for (int i = 0; i < parameters.Length; i++)
                        convertedArgs[i] = Convert.ChangeType(args[i], parameters[i].ParameterType);
                }
                catch (Exception e)
                {
                    return $"Arguments converting error: {e.Message}";
                }

                command.Invoke(target, convertedArgs);
                return $"Executed {commandName}";
            }
            
            return $"Command not found {commandName}";
        }
    }
}