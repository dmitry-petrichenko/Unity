using System;
using ID5D6AAC.Common.EventDispatcher;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EventDispatcher e = new EventDispatcher();
            e.AddEventListener("asa", () => Console.WriteLine("hello"));
            e.AddEventListener("asa", () => Console.WriteLine("hello2"));
            e.AddEventListener("as1", () => Console.WriteLine("hello3"));
            
            e.AddEventListener<int>("asaAkira", Wright);
            
            e.DispatchEvent("asa");
            e.DispatchEvent("asaAkira", 16);
        }

        static void Wright(int i)
        {
            Console.WriteLine(i);
        }
    }
}