using System.Collections;

namespace SAOD_con;

public class MyList<T> : IEnumerable<T>
{
    private MyListItem<T>? First;
    private MyListItem<T>? Last;

    public MyList()
    {
    }

    public MyList(IEnumerable<T> collection)
    {
        foreach (var item in collection) Add(item);
    }

    public int Count
    {
        get
        {
            if (First == null) return 0;
            var count = 1;
            var temp = First;
            while (temp.Next != null)
            {
                temp = temp.Next;
                count++;
            }

            return count;
        }
    }

    public T this[int index] => Get(index);

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T value)
    {
        if (First == null)
        {
            First = new MyListItem<T>(null, null, value);
            Last = First;
        }
        else
        {
            var temp = new MyListItem<T>(Last, null, value);
            Last.Next = temp;
            Last = temp;
        }
    }

    public void RemoveByIndex(int index)
    {
        var prev = GetItem(index - 1);
        var next = GetItem(index + 1);

        prev.Next = next;
        next.Previous = prev;
    }

    public void Remove(T item)
    {
        if (item == null) throw new ArgumentNullException(paramName:nameof(item));
        //if (First == null) throw new ArgumentException($"{item} not in List");
        
        for (var temp = First; temp is not null; temp = temp.Next)
        {
            if (EqualityComparer<T>.Default.Equals(temp.Value, item))
            {
                if (temp.Previous != null)
                {
                    temp.Previous.Next = temp.Next;
                }

                if (temp.Next != null)
                {
                    temp.Next.Previous = temp.Previous;
                }

                if (temp == First)
                {
                    First = temp.Next;
                }

                if (temp == Last)
                {
                    Last = temp.Previous;
                }

                return;
            }
        }
        
        throw new ArgumentException($"{item} not in List");
    }

    private MyListItem<T> GetItem(int index)
    {
        // считаем с конца, -1 - индекс последнего элемента
        if (index < 0)
        {
            if (Last == null) throw new IndexOutOfRangeException();
            var temp = Last;

            for (var i = -1; i > index; i--)
            {
                temp = temp.Previous;

                if (temp == null) throw new IndexOutOfRangeException();
            }

            return temp;
        }
        // прямой порядок
        else
        {
            if (First == null) throw new IndexOutOfRangeException();
            var temp = First;

            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;

                if (temp == null) throw new IndexOutOfRangeException();
            }

            return temp;
        }
    }

    public T Get(int index)
    {
        return GetItem(index).Value;
    }

    public void Insert(int index, T value)
    {
        MyListItem<T> newItem;

        if (index == 0)
        {
            newItem = new MyListItem<T>(null, First, value);
            if (First != null) First.Previous = newItem;
            First = newItem;
        }
        else if (index == Count - 1)
        {
            newItem = new MyListItem<T>(Last, null, value);
            Last = newItem;
        }
        else
        {
            var prev = GetItem(index - 1);
            var next = GetItem(index);

            newItem = new MyListItem<T>(prev, next, value);
            next.Previous = newItem;
            prev.Next = newItem;
        }
    }

    public bool Contains(T item)
    {
        if (item == null) throw new ArgumentNullException(paramName:nameof(item));
        if (First is null) return false;
        if (EqualityComparer<T>.Default.Equals(First.Value, item)) return true;

        for (var temp = First; temp is not null; temp = temp.Next)
        {
            if (EqualityComparer<T>.Default.Equals(temp.Value, item)) return true;
        }

        return false;
    }

    public void Clear()
    {
        First = null;
        Last = null;
    }

    public override string ToString()
    {
        var result = "[";

        var temp = First;
        if (temp == null) return "[ ]";

        while (true)
        {
            result += temp + ", ";
            if (temp.Next == null) break;
            temp = temp.Next;
        }

        return result.Substring(0, result.Length - 2) + "]";
    }
}