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
            q1.Enqueue("fifth");
            foreach (var variable in q1)
            {
                Console.WriteLine(variable);
            }
            q1.Dequeue();
            Console.WriteLine('\n');
            
            foreach (var variable in q1)
            {
                Console.WriteLine( variable);
            }
            Console.ReadLine();
            
        }
    }
}
