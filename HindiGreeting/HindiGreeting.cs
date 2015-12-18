using Greeting;
using Greeting.Interface;

namespace HindiGreeting
{
    [GreetingsPlugin("This greeting is in Hindi.")]
    public class HindiGreeting : IGreeting
    {
        public string GreetMe(string yourName)
        {
            return $"नमस्ते {yourName} जी, आज आप कैसे हैं?";
        }

        public string LanguageSymbol { get; } = "hn";
        public string Language { get; } = "हिंदी";
    }
}
