using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringQueue;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStringQueue q1 = new CustomStringQueue("first", "second", "third", "fourth");
            Console.WriteLine(  q1.Peek());
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine( '\n');
            Console.WriteLine("fifth: " + q1.Contain("fifth") + '\n');
            q1.Enqueue("fifth");
            Console.WriteLine("fifth: " + q1.Contain("fifth") + '\n');
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }
            q1.Dequeue();
            Console.WriteLine('\n'+"before clear");
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }
            CustomStringQueue q2 = q1.Clone();
            q1.Clear();
            Console.WriteLine('\n'+"after Clear()");
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }

            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            q1.Enqueue("fifth");
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine('\n');
            foreach (var variable in q2)
            {
                Console.WriteLine(variable);
            }
            Console.ReadLine();
            
        }
    }
}
