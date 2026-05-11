// Запись данных в файлы (без сериализации)
class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>()
        {
            new Book { Title = "Сказка", Author = "А.С. Евчук", Year = 1933 },
            new Book { Title = "Указы рыцаря", Author = "С.Г. Молчанов", Year = 1900 },
            new Book { Title = "Цветы в вазе", Author = "В.И. Новчик", Year = 1962 },
            new Book { Title = "Воля", Author = "П.Т. Рубцова", Year = 1891 }
        };
        BookJsonWriter bookJsonWriter = new BookJsonWriter();
        bookJsonWriter.WriteBooksAsJson(books);
    }
}