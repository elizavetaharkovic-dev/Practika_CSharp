class Deal
{
    public int Id { get; set; }
    public float Revenue { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Revenue: {Revenue}";
    }
}