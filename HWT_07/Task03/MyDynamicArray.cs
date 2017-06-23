namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyDynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        private int position = -1;

        public MyDynamicArray()
        {
            Array = new T[8];
        }

        public MyDynamicArray(int i)
        {
            Array = new T[i];
        }

        public MyDynamicArray(IEnumerable<T> collection)
        {
            Array = collection.ToArray();
        }

        public T[] Array { get; private set; }
        
        public int Length
        {
            get { return Array.Where(x => x != null).Count(); }
        }

        public int Capacity
        {
            get { return Array.Length; }
        }

        public T Current
        {
            get
            {
                return Array[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Array[position];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return Array[index];
            }

            set
            {
                if (index > Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Array[index] = value;
            }
        }

        public void Add(T item)
        {
            var length = Length;

            if (Array.Length == length)
            {
                Expand(length * 2);
            }

            Array[length] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection.Count() + Length > Capacity)
            {
                var cap = Capacity;

                while (cap < collection.Count() + Length)
                {
                    cap = cap * 2;
                }

                Expand(cap);
            }

            var i = Length;

            foreach (T item in collection)
            {
                Array[i] = item;
                i++;
            }
        }

        public bool Remove(int index)
        {
            if (index > Length)
            {
                return false;
            }

            var temp1 = Array.Take(index - 1).ToArray();
            var temp2 = Array.Skip(index).ToArray();
            Array = new T[Capacity];
            temp1.CopyTo(Array, 0);
            temp2.CopyTo(Array, index);
            return true;
        }

        public bool Insert(T item, int index)
        {
            if (index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            var cap = Capacity;

            if (Length == cap)
            {
                cap = cap * 2;//todo pn 1. хардкод. 2. не очень хорошо. Представь, что в массие 1млн записей, а ты хочешь добавить 10. Для чего так много добавляеть. Лучше в константу вынеси какое-то значение (1000 например).
            }

            var temp1 = Array.Take(index).ToArray();
            var temp2 = Array.Skip(index).Where(x => x != null).ToArray();
            Array = new T[cap];
            temp1.CopyTo(Array, 0);
            Add(item);
            temp2.CopyTo(Array, index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return (position < Length);
        }

        public void Reset()
        {
            position = -1;
        }

        private void Expand(int capacity)
        {
            var temp = Array;
            Array = new T[capacity];
            temp.CopyTo(Array, 0);
        }
    }
}
