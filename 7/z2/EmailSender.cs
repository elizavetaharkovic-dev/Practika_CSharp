using System.Net.Mail;
class EmailSender
{
    public void SendEmail(string email)
    {
        throw new SmtpException($"Сервер недоступен при отправке на {email}");
    }
}