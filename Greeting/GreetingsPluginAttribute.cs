using System;

namespace Greeting
{
    /// <summary>
    /// Use this attribute on your plugins just so it is explicitly clear that it IS
    /// an attribute from the metadata too. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GreetingsPluginAttribute: Attribute
    {
        public GreetingsPluginAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
