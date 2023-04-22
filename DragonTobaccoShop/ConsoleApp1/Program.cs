using Abstractions.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var requiredProperty = typeof(ICartSessionModel<>).GetProperties()
                           .Where(p => p.PropertyType.IsGenericParameter && p.Name == "ID").FirstOrDefault();

            Console.WriteLine(requiredProperty);
        }
    }
}