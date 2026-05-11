public class Patient : IPatientObserver
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Patient(string name, string phone, DateTime appointmentDate)
    {
        Name = name;
        Phone = phone;
        AppointmentDate = appointmentDate;
    }
    public void Update(string message)
    {
        Console.WriteLine($"[{Name}] Получено уведомление: {message}");
    }
    public void ShowAppointmentInfo()
    {
        Console.WriteLine($"Пациент: {Name}, Телефон: {Phone}, Дата приёма: {AppointmentDate:dd.MM.yyyy HH:mm}");
    }
}