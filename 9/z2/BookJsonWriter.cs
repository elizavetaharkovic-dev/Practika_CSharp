class BookJsonWriter
{
    public void WriteBooksAsJson(List<Book> books)
    {
        string json = "[";
        for (int i = 0; i < books.Count; i++)
        {
            Book b = books[i];
            json += $"{{ \"Title\":\"{b.Title}\", \"Author\":\"{b.Author}\", \"Year\":{b.Year} }}";
            if (i < books.Count - 1) json += ",";
        }
        json += "]";
        File.WriteAllText("file.data", json);
    }
}