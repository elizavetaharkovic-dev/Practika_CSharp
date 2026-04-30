class MyDeque<T>
{
    private List<T> array = new List<T>();
    public void AddFirst(T item)
    {
        array.Insert(0, item);
    }
    public void AddLast(T item)
    {
        array.Add(item);
    }
    public void RemoveFirst()
    {
        array.RemoveAt(0);
    }
    public void RemoveLast()
    {
        array.RemoveAt(array.Count - 1);
    }
    internal bool Contains(T item)
    {
        return array.Contains(item);
    }
    internal void Sort()
    {
        array.Sort();
    }
    public List<T> GetAllItems()
    {
        return array;
    }
}