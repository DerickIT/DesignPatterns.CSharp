using SingletonPattern;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Singleton");
            Enumerable.Range(1, 5).Select(
                i => Task.Run(() =>
            {
                Console.WriteLine($"{Singleton.GetInstance().GetHashCode()}");
            })
                ).ToList();
            //Enumerable.Range(1, 100).AsParallel().ForAll(i => { Console.WriteLine(i); });
            Console.WriteLine($"Singleton1");
            Enumerable.Range(1, 5).Select(i => Task.Run(() =>
            {
                Console.WriteLine($"{Singleton1.GetInstance().GetHashCode()}");
            })).ToList();

            Console.WriteLine($"Singleton2");
            Enumerable.Range(1, 5).Select(i => Task.Run(() =>
            {
                Console.WriteLine($"{Singleton2.GetInstance().GetHashCode()}");
            })).ToList();

            Console.WriteLine($"Singleton3");
            var ss=  Enumerable.Range(1, 5).Select(i => Task.Run(() =>
            {
                Console.WriteLine($"{Singleton3.GetInstance().GetHashCode()}");
            })).ToList();

            Console.ReadLine();
        }
    }
}
