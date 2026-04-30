class NotifierManager<T>
{
    public List<INotifier<T>> notifiers = new List<INotifier<T>>();
    public void AddNotifier(INotifier<T> notifier)
    {
        notifiers.Add(notifier);
    }
    public void ClearNotifiers()
    {
        notifiers.Clear();
    }
    public void RemoveNotifier(INotifier<T> notifier)
    {
        notifiers.Remove(notifier);
    }
    public List<INotifier<T>> GetAllNotifiers()
    {
        return notifiers;
    }
}