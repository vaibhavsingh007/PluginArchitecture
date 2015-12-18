using Greeting;
using Greeting.Interface;

namespace PluginArchitecture.DefaultPlugin
{
    [GreetingsPlugin("This greeting is in English.")]
    public class  EnglishGreeting : IGreeting
    {
        public string GreetMe(string yourName)
        {
            return $"Hello {yourName}, how are you doing today?";
        }

        public string LanguageSymbol { get; } = "en";
        public string Language { get; } = "English";
    }
}
