using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringQueue
{
    public class CustomStringQueue : IEnumerable, ICloneable
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

        public string Peek()
        {
            if (IsEmpty())
                return queue[head];
            else
                throw new ArgumentException("The queue is empty!");
        }

        public void Clear()
        {
            for (int i = head, j = 0; j < capacity; j++)
            {
                queue[i] = null;
                i = ++i % capacity;
            }
            head = tail = 0;
        }

        public bool Contain(string str)
        {
            foreach (var variable in queue)
            {
                if (variable == str)
                    return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = head; i < tail;i++)
            {
                yield return queue[i];
            }
        }

        public CustomStringQueue Clone()
        {
            return new CustomStringQueue(queue);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private void DeleteHead()
        {
            queue[head] = null;
            head = ++head % capacity;
        }

        private bool IsEmpty()
        {
            return tail % capacity != head % capacity;
        }

    }
}
