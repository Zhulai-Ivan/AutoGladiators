using System.Collections.Generic;
using System.Reflection;
using Core.Attributes;
using Extensions;
using UnityEngine;

namespace Infrastructure.CommandSystem
{
    public class CommandRegistry
    {
        private Dictionary<string, (MethodInfo, object)> _commands = new();

        public CommandRegistry()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            _commands.Clear();

            foreach (var mono in GameObject.FindObjectsOfType<MonoBehaviour>())
            {
                var methods = mono.GetType().
                    GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                
               methods.ForEach(method =>
               {
                   var atr = method.GetCustomAttribute<CommandAttribute>();
                   if (atr != null)
                   {
                       string cmdName = (atr.Name ??  method.Name).ToLower();
                       _commands[cmdName] = (method, mono);
                   }
               }); 
               
            }
        }

        public bool TryGetCommand(string name, out MethodInfo method, out object target)
        {
            if (_commands.TryGetValue(name.ToLower(), out var tuple))
            {
                method = tuple.Item1;
                target = tuple.Item2;
                return true;
            }
            
            method = null;
            target = null;
            return false;
        }
    }
}