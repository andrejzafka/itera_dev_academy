/// This is example of creating and using generic classes and methods in C#.
/// 
/// For more information about generic classes go to https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/.
/// 

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExample
{
    // This is generic class which takes any type a stores it in a list.
    public class MyGenericList<T>
    {
        private List<T> genericList = new List<T>();

        // This is generic method.
        public void Add(T item)
        {
            genericList.Add(item);
        }

        // This is generic method.
        public int IndexOf(T item)
        {
            return genericList.IndexOf(item);
        }

        // This is generic method.
        public T Get(int index)
        {
            return genericList[index];
        }
    }

    class Kitty
    {        
        public string Name { get; set; }
    }

    class Sqirrel
    {
        public string Color { get; set; }
    }

    class TestGenericList
    {
        static void Main()
        {
            // Store any integer in my generic list.
            MyGenericList<int> integerList = new MyGenericList<int>();
            integerList.Add(1);
            integerList.Add(42);

            // Retrieve index of my integer
            var index = integerList.IndexOf(42);
            Console.WriteLine($"Index of 42 is {index}.");

            // Store any string in my generic list.
            MyGenericList<string> stringList = new MyGenericList<string>();
            stringList.Add("Black kittens bring luck an happiness.");

            // Store any kitty in my generic list.
            MyGenericList<Kitty> kittensList = new MyGenericList<Kitty>();
            kittensList.Add(new Kitty()
            {
                Name = "Fluffs"
            });
            kittensList.Add(new Kitty()
            {
                Name = "Scratchy"
            });

            // Store lots of sqirrels in my generic list.
            MyGenericList<Sqirrel> squrrelsList = new MyGenericList<Sqirrel>();
            squrrelsList.Add(new Sqirrel()
            {
                Color = "purple"
            });

            squrrelsList.Add(new Sqirrel()
            {
                Color = "red"
            });
        }
    }
}
