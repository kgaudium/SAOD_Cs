using System.Net.Sockets;

namespace SAOD_con;

public class MyHashSet<T>
{
    private MyList<T>[] buckets;
    

    public MyHashSet()
    {
        buckets = new MyList<T>[5];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new MyList<T>();
        }
    }

    public bool Add(T item)
    {
        int bucketNum = item.GetHashCode() % buckets.Length;
        bool isAdded = false;

        if (buckets[bucketNum].Contains(item))
        {
            buckets[bucketNum].Add(item);
            isAdded = true;
        }

        return isAdded;
    }

    public void Remove(T item)
    {
        int bucketNum = item.GetHashCode() % buckets.Length;

        if (buckets[bucketNum].Contains(item))
        {
            throw new ArgumentException($"{item} not in Set");
        }
        
        buckets[bucketNum].Remove(item);
    }

}