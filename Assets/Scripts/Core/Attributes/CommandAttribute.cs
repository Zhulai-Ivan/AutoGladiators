using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; }
        public CommandAttribute(string name = null)
        {
            Name = name;
        }
    }
}
