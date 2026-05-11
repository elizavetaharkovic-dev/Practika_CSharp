public class Clinic
{
    private List<IPatientObserver> _patients = new List<IPatientObserver>();
    private List<Patient> _patientData = new List<Patient>();
    public void AddPatient(Patient patient)
    {
        _patientData.Add(patient);
        Subscribe(patient);
        Console.WriteLine($"Пациент {patient.Name} добавлен в клинику");
    }
    public void Subscribe(IPatientObserver observer)
    {
        _patients.Add(observer);
        Console.WriteLine($"Подписчик добавлен");
    }
    public void Unsubscribe(IPatientObserver observer)
    {
        _patients.Remove(observer);
        Console.WriteLine($"Подписчик удалён");
    }
    public void SendReminders()
    {
        Console.WriteLine("\n=== Рассылка напоминаний ===\n");

        foreach (var patient in _patientData)
        {
            TimeSpan timeUntilAppointment = patient.AppointmentDate - DateTime.Now;

            if (timeUntilAppointment.TotalDays <= 1 && timeUntilAppointment.TotalDays >= 0)
            {
                string message = $"Напоминание! Ваш приём завтра в {patient.AppointmentDate:HH:mm}";
                patient.Update(message);
            }
            else if (timeUntilAppointment.TotalDays < 0)
            {
                Console.WriteLine($"[{patient.Name}] Приём уже прошёл");
            }
        }
        Console.WriteLine();
    }
    public void CheckDailyReminders()
    {
        SendReminders();
    }
}