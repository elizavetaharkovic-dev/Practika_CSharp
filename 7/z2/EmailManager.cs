using System.Net.Mail;

class EmailManager
{
    public void SendMessage(string email)
    {
        EmailSender emailSender = new EmailSender();
        try
        {
            emailSender.SendEmail(email);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex.Message);
            throw new EmailSendingException("Не удалось отправить письмо", ex);
        }
    }
}