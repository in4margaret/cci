using System;

namespace cci
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new HashMap<String, String>();
            map.Add("panda", "34");
            Console.WriteLine(map.GetValue("panda"));
            map.Add("panda", "39");
            Console.WriteLine(map.GetValue("panda"));
            Console.WriteLine(map.GetValue("red panda"));
            map.Add("penguin", "10000");
            Console.WriteLine(map.GetValue("penguin"));
            map.DeleteValue("penguin");
            Console.WriteLine(map.GetValue("penguin"));
        }
    }
}
