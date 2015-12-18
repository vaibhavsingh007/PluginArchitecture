using Greeting;
using Greeting.Interface;

namespace SwedishGreeting
{
    [GreetingsPlugin("This greeting is in Swedish.")]
    public class SwedishGreeting: IGreeting
    {
        public string GreetMe(string yourName)
        {
            return $"Hej {yourName}, hur mår du idag?";
        }

        public string LanguageSymbol { get; } = "sv";
        public string Language { get; } = "Svenska";
    }
}
