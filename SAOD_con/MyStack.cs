using System;

namespace SAOD_con
{

    public class MyStack<T>
    {
        // TODO реализовать интерфейс Iterable(?)
        private T[] items;
        private int length;
        private readonly int maxLength;

        public MyStack(int Length)
        {
            this.maxLength = Length;
            this.length = 0;
            this.items = new T[Length];
        }

        public T[] GetArray()
        {
            return items;
        }

        public void Push(T item)
        {
            if (length == maxLength)
                throw new Exception(
                    $"Cannot push new item to position {length + 1}: stack max size is {maxLength}");
            items[length++] = item;
        }

        public T Pop()
        {
            if (length <= 0) throw new Exception("Cannot pop item: stack is empty");
            return items[--length];
        }

        public T Top()
        {
            if (length == 0) throw new Exception("Stack is empty");
            return items[length];
        }

        public void Clear()
        {
            items = new T[length];
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public int GetLength()
        {
            return length;
        }

        public int GetMaxLength()
        {
            return maxLength;
        }
    }
}