using Greeting.Interface;
using PluginArchitecture.DefaultPlugin;

namespace PluginArchitecture
{
    /*
    Injecting our implementation of the IGreeting interface with the constructor, 
    we could provide a default behavior (English) for a host class while at the same 
    time allowing for other implementations to be injected into our host class. 
    This pattern also makes the host class easier to unit test.
    */
    public class PluginHost
    {
        private readonly IGreeting _greeting;

        public PluginHost() : this(new EnglishGreeting())
        {
            
        }

        public PluginHost(IGreeting greeting)
        {
            _greeting = greeting;
        }

        public string Greet(string name) => _greeting.GreetMe(name);

        public string Symbol => _greeting.LanguageSymbol;

        public string Language => _greeting.Language;
    }
}
