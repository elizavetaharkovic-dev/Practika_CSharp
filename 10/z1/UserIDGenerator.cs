public class UserIDGenerator
{
    private static UserIDGenerator _instance;
    private static readonly object _lock = new object();
    private int _currentId = 0;

    private UserIDGenerator() { }

    public static UserIDGenerator Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UserIDGenerator();
                }
                return _instance;
            }
        }
    }

    public int GenerateID()
    {
        _currentId++;
        return _currentId;
    }
}