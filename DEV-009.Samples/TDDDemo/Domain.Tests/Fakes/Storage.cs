namespace Domain.Tests.Fakes
{
    public class Storage
    {
        private readonly IEmailSender _emailSender;

        public Storage(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Save()
        {
            _emailSender.Send("saved");
        }
    }
}