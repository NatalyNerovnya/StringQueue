using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class QueueIterartor : IEnumerator
    {
        public string[] array;
        private int position = -1;

        public QueueIterartor(string[] list)
        {
            array = list;
        }

        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }
            position++;
            return true;
        }

        public void Reset()
        {
            position = -1;
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
