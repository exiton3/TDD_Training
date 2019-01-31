namespace Domain.Tests.Fakes
{
    public interface IEmailSender
    {
        void Send(string text);
    }
}