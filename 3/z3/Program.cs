// задание 3

public abstract class Pet
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string OwnerName { get; set; }
}

public sealed class Dog : Pet { }

public sealed class Cat : Pet { }

public class VeterinaryClinic
{
    public Pet[] Pets { get; set; }

    public Pet GetOldestPet()
    {
        return Pets.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    public Pet[] GetPetsByOwner(string ownerName)
    {
        return Pets.Where(p => p.OwnerName == ownerName).ToArray();
    }
}

class Program
{
    static void Main()
    {
        VeterinaryClinic clinic = new VeterinaryClinic();
        clinic.Pets = new Pet[]
        {
            new Dog { Name = "Бобик", Breed = "Овчарка", Age = 5, OwnerName = "Анна" },
            new Cat { Name = "Мурка", Breed = "Сиамская", Age = 3, OwnerName = "Анна" },
            new Dog { Name = "Шарик", Breed = "Дворняга", Age = 8, OwnerName = "Иван" }
        };

        Pet oldest = clinic.GetOldestPet();
        Console.WriteLine($"Самое старое животное: {oldest.Name}, {oldest.Age} лет");

        Pet[] annasPets = clinic.GetPetsByOwner("Анна");
        Console.WriteLine("Питомцы Анны:");
        foreach (Pet pet in annasPets)
        {
            Console.WriteLine($"- {pet.Name} ({pet.GetType().Name})");
        }
    }
}
