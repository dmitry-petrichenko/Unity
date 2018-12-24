using System;
using ID5D6AAC.Common.EventDispatcher;

namespace ConsoleApp1
{
    class Program
    {
        public const string EVENT_FIRST = "Event1";
        public const string EVENT_SECOND = "Event2";
        
        static void Main(string[] args)
        {
            IEventDispatcher eventDispatcher = new EventDispatcher();
            eventDispatcher.AddEventListener(EVENT_FIRST, () => Console.WriteLine("hello"));
            eventDispatcher.AddEventListener(EVENT_SECOND, () => Console.WriteLine("hello2"));
            eventDispatcher.AddEventListener(EVENT_FIRST, () => Console.WriteLine("hello3"));
            
            eventDispatcher.AddEventListener("asaAkira", Wright2);
            
            eventDispatcher.DispatchEvent(EVENT_FIRST);
            eventDispatcher.DispatchEvent("asaAkira", 16);
            eventDispatcher.DispatchEvent(EVENT_FIRST);
        }

        private static void Wright2()
        {
            Console.WriteLine("hello0");
        }

        static void Wright(int i)
        {
            Console.WriteLine(i);
        }
    }
}