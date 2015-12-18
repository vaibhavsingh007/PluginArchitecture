using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
    class Program
    {
        // As long as you drop the plugin dlls in the Plugin folder in the executing directory,
        //..it should work fine, out-of-the-box.
        static void Main(string[] args)
        {
            Console.WriteLine("Available languages are:");

            // Print all available greeting languages
            foreach (var greeting in PluginHostProvider.Greetings)
            {
                Console.WriteLine(greeting.Symbol);
            }

            Console.WriteLine("\nPlease enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please select a language symbol: ");
            string languageSymbol = Console.ReadLine();

            var selectedGreeting = PluginHostProvider.Greetings.FirstOrDefault(g => g.Symbol.Equals(languageSymbol)) ?? PluginHostProvider.Greetings.Find(g => g.Symbol == "en");

            Console.WriteLine($"Selected greeting language is {selectedGreeting.Language}.\n");
            Console.WriteLine(selectedGreeting.Greet(name));
            Console.ReadLine();
        }
    }
}
