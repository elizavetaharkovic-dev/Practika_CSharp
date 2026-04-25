// 13. Виды пользователей в системе
// Создать абстрактный класс User с методом GetPermissions(). Создать три типа
// пользователей: Admin, Moderator, Guest. Заполнить массив пользователями и вывести их
// права доступа.
class Program
{
    static void Main()
    {
        User[] users = new User[4]; 
        users[0] = new Admin("Влад");
        users[1] = new Moderator("Маша");
        users[2] = new Guest("Вася");
        users[3] = new Guest("Настя");
        foreach (User u in users)
        {
            u.GetPermissions();
        }
    }
}