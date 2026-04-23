// Создайте static классы, которые выполняют различные операции с массивами
// объектов, включая сортировку, фильтрацию, вычисление статистики и генерацию данных.
// Добавить метод ReverseArray, который меняет порядок элементов в массиве Person на обратный.

bool programRunning = true;    // флажок выполнения программы
object myArray;

while (programRunning)
{
    Console.WriteLine("Выберите способ заполнения массива\n" +
        "1. Заполнить строки вручную\n" +
        "2. Сгенерировать числа\n" +
        "3. Выйти");
    string fillChoice = Console.ReadLine();

    if (fillChoice == "1")
    {
        myArray = Persone.InputOutput();  // ручной
    }
    else if (fillChoice == "2")
    {
        myArray = Persone.GenerationArray();     // генерация
    }
    else if (fillChoice == "3")
    {
        programRunning = false;
        break;
    }
    else
    {
        Console.WriteLine("Неверный выбор");
        continue;
    }

    bool workingWithArray = true;    // флажок работы с массивом

    while (workingWithArray)
    {
        Console.WriteLine("\nВыберите что сделать с массивом" +
            "\n1. Перевернуть\n" +
            "2. Отсортировать\n" +
            "3. Фильтрация\n" +
            "4. Статистика\n" +
            "5. Вернуться к заполнению\n" +
            "6. Выйти");
        string operation = Console.ReadLine();

        switch (operation)
        {
            case "1":
                if (myArray is string[])
                {
                    myArray = Persone.ReverseArray((string[])myArray);
                    Console.WriteLine("Получившийся перевернутый массив: " + string.Join(" ", (string[])myArray));
                }

                else if (myArray is int[])
                {
                    myArray = Persone.ReverseArray((int[])myArray);
                    Console.WriteLine("Получившийся перевернутый массив: " + string.Join(" ", (int[])myArray));
                }
                break;
            case "2":
                if (myArray is string[])
                {
                    myArray = Persone.SortArray((string[])myArray);
                    Console.WriteLine("Получившийся отсортированный массив: " + string.Join(" ", (string[])myArray));
                }
                else if (myArray is int[])
                {
                    myArray = Persone.SortArray((int[])myArray);
                    Console.WriteLine("Получившийся отсортированный массив: " + string.Join(" ", (int[])myArray));
                }
                break;
            case "3":
                if (myArray is string[])
                    Persone.FilterArray((string[])myArray);
                else if (myArray is int[])
                    Persone.FilterArray((int[])myArray);
                break;
            case "4":
                if (myArray is string[])
                    Persone.StatisticArray((string[])myArray);
                else if (myArray is int[])
                    Persone.StatisticArray((int[])myArray);
                break;
            case "5":
                workingWithArray = false;
                break;
            case "6":
                workingWithArray = false;
                programRunning = false;
                break;
            default:
                Console.WriteLine("Неверный выбор");
                break;
        }
    }
}
static class Persone
{
    static string[] information;
    static int[] number;
    static string orig;
    public static string[] InputOutput()
    {
        Console.WriteLine("Введите имя, фамилию, возраст, рост, вес через пробел");
        orig = Console.ReadLine();
        information = orig.Split(' ');
        return information;
    }
    public static int[] GenerationArray()
    {
        Console.Write("Введите размерность одномерного массива: ");
        int size = int.Parse(Console.ReadLine());
        number = new int[size];
        Random rnd = new Random();
        for (int i = 0; i < size; i++) number[i] = rnd.Next(-99, 100);
        Console.WriteLine("Исходный массив: " + string.Join(" ", number));
        return number;
    }

    public static string[] ReverseArray(string[] information)
    {
        Array.Reverse(information);
        return information;
    }
    public static int[] ReverseArray(int[] number)
    {
        Array.Reverse(number);
        return number;
    }
    public static string[] SortArray(string[] information)
    {
        Array.Sort(information);
        return information;
    }
    public static int[] SortArray(int[] number)
    {
        Array.Sort(number);
        return number;
    }
    public static void FilterArray(int[] number)
    {
        Console.WriteLine($"Выберите фильтрацию:\n1. Выведи числа в диапазоне [X, Y]\n2. Выведи четные числа\n3. Выведи нечетные числа");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.Write("X= ");
            int X = int.Parse(Console.ReadLine());
            Console.Write("Y= ");
            int Y = int.Parse(Console.ReadLine());
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= X && number[i] <= Y) Console.Write(number[i] + " ");
            }
        }
        else if (choice == "2")
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 == 0) Console.Write(number[i] + " ");

            }
        }
        else if (choice == "3")
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 != 0) Console.Write(number[i] + " ");

            }
        }
        else Console.WriteLine("Такого варианта нет!");
    }
    public static void FilterArray(string[] information)
    { 
        Console.WriteLine($"Выберите фильтрацию:\n1. Выведи имя\n2. Выведи фамилию\n3. Выведи возраст, рост и вес");
        string choice = Console.ReadLine();
        if (choice == "1") Console.WriteLine($"Имя: {information[0]}");
        else if (choice == "2") Console.WriteLine($"Фамилия: {information[1]}");
        else if (choice == "3") Console.WriteLine($"Возраст: {information[2]}, Рост: {information[3]}, Вес: {information[4]}");
        else Console.WriteLine("Такого варианта нету!");
    }
    public static void StatisticArray(int[] number)
    {
        int sum = 0;
        for (int i = 0;i < number.Length;i++)
        {
            sum += number[i];
        }
        double avg = 1.0 * sum / number.Length;
        int max = number.Max();
        int min = number.Min();
        Console.WriteLine($"Среднее арифметическое всех элементов массива: {avg:F3}\nМаксимальный элемент массива: {max}\nМинимальный элемент массива: {min}");
    }
    public static void StatisticArray(string[] information)
    {
        string longest = information[0];
        string shortest = information[0];
        foreach (string str in information)
        {
            if (str.Length > longest.Length) longest = str;
            if (str.Length < shortest.Length) shortest = str;
        }
        Console.WriteLine($"Самая длинная строка: {longest}\nСамая короткая строка: {shortest}");
    }
}