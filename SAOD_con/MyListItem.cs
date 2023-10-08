namespace SAOD_con;

internal class MyListItem<T>
{
    internal MyListItem<T>? Previous;
    internal MyListItem<T>? Next;

    public T Value;

    internal MyListItem(MyListItem<T> prev, MyListItem<T> next, T value)
    {
        Previous = prev;
        Next = next;
        Value = value;
    }
    
    /// <summary>
    /// Compares only values of MyListItem. To fully compare two items use Equals instead
    /// </summary>
    public static bool operator ==(MyListItem<T>? a, MyListItem<T>? b)
    {
        if (a is null || b is null) return false;
        return EqualityComparer<T>.Default.Equals(a.Value, b.Value);
    }
    
    /// <summary>
    /// Compares only values of MyListItem. To fully compare two items use Equals instead
    /// </summary>
    public static bool operator !=(MyListItem<T>? a, MyListItem<T>? b)
    {
        if (a is null || b is null) return false;
        return !(EqualityComparer<T>.Default.Equals(a.Value, b.Value));
    }

    /// <summary>
    /// Compares all fields of item. If you want to compare only Value use operator == or get Value value
    /// </summary>
    public override bool Equals(object? obj)
    {
        return (obj is MyListItem<T> item) && (Equals(item));
    }
    
    /// <summary>
    /// Compares all fields of item. If you want to compare only Value use operator == or get Value value
    /// </summary>
    internal bool Equals(MyListItem<T>? other)
    {
        if (other is null) return false;
        return Equals(Previous, other.Previous) && Equals(Next, other.Next) && EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    /// <summary>
    /// Returns combined Hash of Previous, Next and Value fields
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Previous, Next, Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}