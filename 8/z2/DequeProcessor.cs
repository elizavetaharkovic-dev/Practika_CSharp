class DequeProcessor<T>
{
    public MyDeque<T> items = new MyDeque<T>();
    public string FindItem(T item)
    {
        if (items.Contains(item))
            return $"Элемент {item} найден!";
        else
            return $"Элемент {item} не найден.";
    }
    public void SortItems()
    {
        items.Sort();
        ShowInfo();  
    }
    public void ShowInfo()
    {
        Console.WriteLine(string.Join(" ", items.GetAllItems()));
    }
}