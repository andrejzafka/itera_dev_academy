/// 
/// This is example project about compiling C# code to .NET Intermediate Language.
/// using tool iladsm.exe.
/// 
/// For more information about .NET IL and Common Language Runtime go to https://docs.microsoft.com/en-us/dotnet/standard/clr.
/// 


using System;
namespace CalculatorExample
{
    class Program
    {
        static void Main()
        {
            Calc c = new Calc();
            int ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}.", ans);
            Console.ReadLine();
        }
    }

    class Calc
    {
        public int Add(int x, int y)
        { return x + y; }
    }
}
