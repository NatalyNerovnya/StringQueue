using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program;

namespace StringQueue
{
    public class CustomStringQueue : IEnumerable
    {
        private string[] queue;
        private int capacity, head, tail;
        private static int defaultCapacity = 8;

        public CustomStringQueue() : this(defaultCapacity) { }

        public CustomStringQueue(int n)
        {
            if (n > 0)
            {
                queue = new string[n];
                capacity = n;
            }
            else
                throw new ArgumentException();
        
            head = 0;
            tail = 0;
        }

        public CustomStringQueue(params string[] arr)
            : this(arr.Length)
        {
            Array.Copy(arr, queue, capacity);
            tail = capacity - 1;
        }


        public void Enqueue(string element)
        {
            if ((tail + 1) % capacity == head % capacity)
            {
                string[] wideQueue = new string[capacity * 2];

                for (int i = head, j = 0; j < capacity; j++)
                {
                    wideQueue[j] = queue[i];
                    i = ++i % capacity;
                }
                wideQueue[capacity] = element;
                tail = capacity;
                head = 0;
                capacity *= 2;
                queue = wideQueue;
            }
            else
            {
                queue[++tail % capacity] = element;
                tail = tail % capacity;
            }

        }

        public string Dequeue()
        {
            if (IsEmpty())
            {
                string returnValue = Peek();
                DeleteHead();
                return returnValue;
            }
            else
                throw new ArgumentException("The queue is empty!");
        }

        private void DeleteHead()
        {
            queue[head] = null;
            head = ++head % capacity;
        }

        private bool IsEmpty()
        {
            if (tail % capacity == head % capacity)
                return false;
            else
                return true;
        }

        public string Peek()
        {
            if (IsEmpty())
                return queue[head];
            else
                throw new ArgumentException("The queue is empty!");
        }

        public void ShowQueue()
        {
            for (int i = head; i <= tail;)
            {
                Console.Write(" " + queue[i]);
                if (i == tail)
                    break;
                i = ++i % capacity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new QueueIterartor(queue);
        }

    }
}
