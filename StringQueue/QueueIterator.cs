using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringQueue;

namespace Program
{
    internal class QueueIterartor : IEnumerator
    {
        public string[] array;
        private int position;
        private readonly int tailPosition, headPosition;

        public QueueIterartor(string[] list, int tail, int head)
        {
            array = list;
            position = (head-1)% list.Length;
            tailPosition = tail;
            headPosition = head;
        }

        public bool MoveNext()
        {
            if (position == tailPosition)
            {
                Reset();
                return false;
            }
            position = ++position % array.Length;
            return true;
        }


        public void Reset()
        {
            position = (headPosition-1)%array.Length;
        }

        object IEnumerator.Current
        {
            get { return array[position]; }
        }

        public string Current
        {
            get { return array[position]; }
        }

        public void Dispose()
        {
        }
    }
}
