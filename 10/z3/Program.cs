// Информирование пациентов о приеме у врача
class Program
{
    static void Main()
    {
        Clinic clinic = new Clinic();

        Patient patient1 = new Patient("Анна Смирнова", "+7-999-123-45-67", DateTime.Now.AddDays(1));
        Patient patient2 = new Patient("Иван Петров", "+7-999-234-56-78", DateTime.Now.AddDays(3));
        Patient patient3 = new Patient("Мария Сидорова", "+7-999-345-67-89", DateTime.Now.AddDays(1));

        clinic.AddPatient(patient1);
        clinic.AddPatient(patient2);
        clinic.AddPatient(patient3);

        Console.WriteLine("\n--- Информация о пациентах ---");
        patient1.ShowAppointmentInfo();
        patient2.ShowAppointmentInfo();
        patient3.ShowAppointmentInfo();

        clinic.CheckDailyReminders();

        Console.WriteLine("\n--- Симуляция прошествия дня ---");
        Console.WriteLine("Прошёл 1 день...\n");

        patient1.AppointmentDate = DateTime.Now.AddDays(-1);
        patient2.AppointmentDate = DateTime.Now.AddDays(2);
        patient3.AppointmentDate = DateTime.Now.AddDays(-1);

        clinic.CheckDailyReminders();
    }
}