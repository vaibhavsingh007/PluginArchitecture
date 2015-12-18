namespace Greeting.Interface
{
    public interface IGreeting
    {
        string GreetMe(string yourName);
        string LanguageSymbol { get; }
        string Language { get; }
    }
}
